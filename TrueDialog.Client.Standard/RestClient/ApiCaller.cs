using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Newtonsoft.Json;

using TrueDialog.Configuration;
using TrueDialog.Helpers;

namespace TrueDialog
{
    internal class ApiCaller : IApiCaller
    {
        private readonly ITrueDialogConfig m_config;

        private bool m_asUser;

        private readonly string m_baseUrl;

        private readonly string m_apiHeader;
        private readonly string m_authHeader;
        private string m_sourceHeader = "CUSTOM";

        public int AccountId { get; set; }

        internal ApiCaller(ITrueDialogConfigProvider configFactory) 
            : this(configFactory.GetConfig())
        {
        }

        internal ApiCaller(ITrueDialogConfig config)
        {
            m_config = config ?? throw new ArgumentException("Config is required!");

            m_config.BaseUrl = string.IsNullOrEmpty(m_config.BaseUrl) ? Defaults.BaseUrl : m_config.BaseUrl;
            m_config.Timeout = m_config.Timeout.HasValue ? m_config.Timeout : Defaults.Timeout;
            m_config.UserAgent = string.IsNullOrEmpty(m_config.UserAgent) ? Defaults.UserAgent : m_config.UserAgent;

            m_baseUrl = m_config.BaseUrl;

            if (!m_baseUrl.EndsWith("/"))
                m_baseUrl += "/";

            if (!String.IsNullOrWhiteSpace(m_config.Username) && !String.IsNullOrWhiteSpace(m_config.Password))
                m_authHeader = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{m_config.Username}:{m_config.Password}"));

            if (!m_config.AccountId.HasValue)
            {
                if (!string.IsNullOrEmpty(m_authHeader))
                {
                    var userinfo = Get<Model.UserInfo>("userinfo", true);
                    m_config.AccountId = userinfo.AccountId;
                    m_config.ApiKey = userinfo.ApiKey.Key;
                    m_config.ApiSecret = userinfo.ApiKey.Secret;
                }
                else if (!string.IsNullOrEmpty(m_config.ApiKey) && !string.IsNullOrEmpty(m_config.ApiSecret))
                {
                    throw new ArgumentException("Account ID must be provided with API key!");
                }
                else
                {
                    throw new ArgumentException("Login credentials required!");
                }
            }

            if (!string.IsNullOrEmpty(m_config.ApiKey) && !string.IsNullOrEmpty(m_config.ApiSecret))
                m_apiHeader = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{m_config.ApiKey}:{m_config.ApiSecret}"));

            AccountId = m_config.AccountId.Value;
        }

        public IApiCaller AsUser()
        {
            m_asUser = true;

            return this;
        }

        public void SetSource(string source)
        {
            m_sourceHeader = source;
        }

        private string AddQueryArgs(string url, string args) => (url.Contains("?") ? "&" : "?") + args;

        private string AddQueryArgs(string url, IEnumerable<string> items) => AddQueryArgs(url, String.Join("&", items));

        private string AddQueryArgs(string url, IEnumerable<KeyValuePair<string, object>> items) =>
            AddQueryArgs(url, items.Select(kvp => String.Format("{0}={1}", HttpUtility.UrlEncode(kvp.Key), HttpUtility.UrlEncode(kvp.Value.ToString()))));

        private string BuildUrl(string url, object urlArgs)
        {
            if (url.StartsWith("/"))
                url = url.Substring(1, url.Length - 1);

            url = m_baseUrl + url;

            if (urlArgs != null)
            {
                foreach (var kvp in ObjectHelper.ToDictionary(urlArgs))
                    url = url.Replace("{" + kvp.Key + "}", HttpUtility.UrlEncode(kvp.Value.ToString()));
            }

            return url;
        }

        private HttpWebRequest BuildRequest(string method, string url, object urlArgs, object headers = null, object oData = null, bool envelope = false)
        {
            url = BuildUrl(url, urlArgs);

            if (oData != null)
            {
                var oDataList =
                (
                    from kvp in ObjectHelper.ToDictionary(oData)
                    let key = kvp.Key[0] == '$' ? kvp.Key : "$" + kvp.Key
                    select String.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(kvp.Value.ToString()))
                ).ToList();

                url = AddQueryArgs(url, oDataList);
            }

            if (envelope)
                url = AddQueryArgs(url, "env=");

            var req = WebRequest.CreateHttp(url);

            if (headers != null)
            {
                foreach (var kvp in ObjectHelper.ToDictionary(headers).Where(kvp => kvp.Key != "Authorization"))
                    req.Headers.Add(kvp.Key, kvp.Value.ToString());
            }

            req.Timeout = (int)m_config.Timeout;
            req.ContentType = "application/json";
            req.Headers.Add("Authorization", string.IsNullOrEmpty(m_apiHeader) || (!string.IsNullOrEmpty(m_authHeader) && m_asUser) ? m_authHeader : m_apiHeader);
            req.Headers.Add("X-TD-SOURCE", m_sourceHeader);
            req.Method = method;

            m_asUser = false;

            return req;
        }

        private async Task<string> ReadResponse(WebResponse response)
        {
            using (var stream = response.GetResponseStream())
            {
                if (stream != null)
                {
                    using (var sr = new StreamReader(stream))
                        return await sr.ReadToEndAsync();
                }
            }

            return string.Empty;
        }

        private async Task<byte[]> ReadResponseAsByteArrayAsync(WebResponse response)
        {
            using (var ms = new MemoryStream())
            {
                using (var stream = response.GetResponseStream())
                {
                    await stream.CopyToAsync(ms);
                }

                return ms.ToArray();
            }
        }

        private async Task<string> RawExecuteAsync(string method, string url, object urlArgs, bool notFoundFail = false, object body = null, object headers = null, object oData = null, bool envelope = false)
        {
            var request = BuildRequest(method, url, urlArgs, headers, oData, envelope);

            if (body != null)
            {
                using (var sw = new StreamWriter(await request.GetRequestStreamAsync()))
                    await sw.WriteAsync(JsonConvert.SerializeObject(body));
            }

            string response;
            string contentType;
            int statusCode;

            try
            {
                using (var resp = await request.GetResponseAsync())
                {
                    response = await ReadResponse(resp);
                    contentType = resp.ContentType;
                    statusCode = (int)((HttpWebResponse)resp).StatusCode;
                }
            }
            catch (WebException ex) when (ex.Response != null)
            {
                response = await ReadResponse(ex.Response);
                contentType = ex.Response.ContentType;
                statusCode = (int)((HttpWebResponse)ex.Response).StatusCode;
            }

            if ((statusCode / 100) >= 4)
            {
                if (statusCode == 404 && !notFoundFail)
                    return default; // Treat 404 has no content

                //if (contentType.ToLower().Contains("application/json"))
                //{
                //    // TODO: Try to parse the error response
                //}

                throw new Exception("Error calling API: " + response);
            }

            if (statusCode == 204)
                return default;

            return response;
        }

        private async Task<HttpWebRequest> BuildMultipartRequest(string url, string contentType, byte[] formData)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);

            // Set up the request properties.
            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = formData.Length;
            request.Headers.Add("Authorization", string.IsNullOrEmpty(m_apiHeader) || (!string.IsNullOrEmpty(m_authHeader) && m_asUser) ? m_authHeader : m_apiHeader);

            // Send the form data to the request.
            using (Stream requestStream = await request.GetRequestStreamAsync())
            {
                requestStream.Write(formData, 0, formData.Length);
                requestStream.Close();
            }

            return request;
        }

        private static byte[] BuildMultipartFormData(Dictionary<string, object> postParameters, string boundary)
        {
            using (Stream formDataStream = new MemoryStream())
            {
                bool needsCLRF = false;

                foreach (var param in postParameters)
                {
                    // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
                    // Skip it on the first parameter, add it to subsequent parameters.
                    if (needsCLRF)
                        formDataStream.Write(Encoding.UTF8.GetBytes("\r\n"), 0, Encoding.UTF8.GetByteCount("\r\n"));

                    needsCLRF = true;

                    if (param.Value is FileParameter)
                    {
                        FileParameter fileToUpload = (FileParameter)param.Value;

                        // Add just the first part of this param, since we will write the file data directly to the Stream
                        string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n",
                            boundary,
                            param.Key,
                            fileToUpload.FileName ?? param.Key,
                            fileToUpload.ContentType ?? "application/octet-stream");

                        formDataStream.Write(Encoding.UTF8.GetBytes(header), 0, Encoding.UTF8.GetByteCount(header));

                        // Write the file data directly to the Stream, rather than serializing it to a string.
                        formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                    }
                    else
                    {
                        string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                            boundary,
                            param.Key,
                            param.Value);
                        formDataStream.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetByteCount(postData));
                    }
                }

                // Add the end of the request.  Start with a newline
                string footer = "\r\n--" + boundary + "--\r\n";
                formDataStream.Write(Encoding.UTF8.GetBytes(footer), 0, Encoding.UTF8.GetByteCount(footer));

                // Dump the Stream into a byte[]
                formDataStream.Position = 0;
                byte[] formData = new byte[formDataStream.Length];
                formDataStream.Read(formData, 0, formData.Length);
                formDataStream.Close();

                return formData;
            }
        }

        private async Task<string> RawMultipartFormDataPostAsync(string url, object urlArgs, Dictionary<string, object> postParameters)
        {
            url = BuildUrl(url, urlArgs);

            string formDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());
            string fdContentType = "multipart/form-data; boundary=" + formDataBoundary;

            byte[] formData = BuildMultipartFormData(postParameters, formDataBoundary);

            var request = await BuildMultipartRequest(url, fdContentType, formData);

            string response;
            string contentType;
            int statusCode;

            try
            {
                using (var resp = await request.GetResponseAsync())
                {
                    response = await ReadResponse(resp);
                    contentType = resp.ContentType;
                    statusCode = (int)((HttpWebResponse)resp).StatusCode;
                }
            }
            catch (WebException ex) when (ex.Response != null)
            {
                response = await ReadResponse(ex.Response);
                contentType = ex.Response.ContentType;
                statusCode = (int)((HttpWebResponse)ex.Response).StatusCode;
            }

            if ((statusCode / 100) >= 4)
            {
                //if (contentType.ToLower().Contains("application/json"))
                //{
                //    // TODO: Try to parse the error response
                //}

                throw new Exception("Error calling API: " + response);
            }

            if (statusCode == 204)
                return default;

            return response;
        }

        private async Task<(string contentType, byte[] content)> RawDownloadAsync(string url, object urlArgs, bool notFoundFail = false, object headers = null, object oData = null)
        {
            var request = BuildRequest("GET", url, urlArgs, headers, oData, false);

            byte[] bytes = new byte[0];
            string response = "empty";
            string contentType;
            int statusCode;

            try
            {
                using (var resp = await request.GetResponseAsync())
                {
                    bytes = await ReadResponseAsByteArrayAsync(resp);
                    contentType = resp.ContentType;
                    statusCode = (int)((HttpWebResponse)resp).StatusCode;
                }
            }
            catch (WebException ex) when (ex.Response != null)
            {
                response = await ReadResponse(ex.Response);
                contentType = ex.Response.ContentType;
                statusCode = (int)((HttpWebResponse)ex.Response).StatusCode;
            }

            if ((statusCode / 100) >= 4)
            {
                if (statusCode == 404 && !notFoundFail)
                    return default; // Treat 404 has no content

                //if (contentType.ToLower().Contains("application/json"))
                //{
                //    // TODO: Try to parse the error response
                //}

                throw new Exception("Error calling API: " + response);
            }

            if (statusCode == 204)
                return default;

            return (contentType, bytes);
        }

        private async Task<T> ExecuteAsync<T>(string method, string url, object urlArgs, bool notFoundFail = false, object body = null, object headers = null, object oData = null, bool envelope = false)
        {
            string data = await RawExecuteAsync(method, url, urlArgs, notFoundFail, body, headers, oData, envelope);
            return JsonConvert.DeserializeObject<T>(data);
        }

        private async Task<T> UploadAsync<T>(string url, object urlArgs, FileParameter file)
        {
            string data = await RawMultipartFormDataPostAsync(url, urlArgs, new Dictionary<string, object> { { "media", file } });
            return JsonConvert.DeserializeObject<T>(data);
        }

        public T Get<T>(string url, bool throwIfEmpty = false, object oData = null)
        {
            return GetAsync<T>(url, throwIfEmpty).GetAwaiter().GetResult();
        }

        public async Task<T> GetAsync<T>(string url, bool throwIfEmpty = false, object oData = null)
        {
            return await ExecuteAsync<T>("GET", url, null, !throwIfEmpty, oData: oData);
        }

        public T Post<T>(string url, T data, object oData = null)
        {
            return PostAsync(url, data, oData).GetAwaiter().GetResult();
        }

        public async Task<T> PostAsync<T>(string url, T data, object oData = null)
        {
            return await ExecuteAsync<T>("POST", url, null, true, data, oData: oData);
        }

        public T Post<T>(string url, object data, object oData = null)
        {
            return PostAsync<T>(url, data, oData).GetAwaiter().GetResult();
        }

        public async Task<T> PostAsync<T>(string url, object data, object oData = null)
        {
            return await ExecuteAsync<T>("POST", url, null, true, data, oData: oData);
        }

        public T Put<T>(string url, T data)
        {
            return PutAsync(url, data).GetAwaiter().GetResult();
        }

        public async Task<T> PutAsync<T>(string url, T data)
        {
            return await ExecuteAsync<T>("PUT", url, null, true, data);
        }

        public T Put<T>(string url, object data)
        {
            return PutAsync<T>(url, data).GetAwaiter().GetResult();
        }

        public async Task<T> PutAsync<T>(string url, object data)
        {
            return await ExecuteAsync<T>("PUT", url, null, true, data);
        }

        public void Delete(string url)
        {
            DeleteAsync(url).GetAwaiter().GetResult();
        }

        public async Task DeleteAsync(string url)
        {
            await RawExecuteAsync("DELETE", url, null);
        }

        public async Task<(string contentType, byte[] content)> DownloadAsync(string url)
        {
            return await RawDownloadAsync(url, null);
        }

        public (string contentType, byte[] content) Download(string url)
        {
            return DownloadAsync(url).GetAwaiter().GetResult();
        }

        public async Task<T> UploadAsync<T>(string url, byte[] bytes, string contentType, string fileName)
        {
            var file = new FileParameter(bytes, fileName, contentType);
            
            return await UploadAsync<T>(url, null, file);
        }

        public T Upload<T>(string url, byte[] bytes, string contentType, string fileName)
        {
            return UploadAsync<T>(url, bytes, contentType, fileName).GetAwaiter().GetResult();
        }
    }
}
