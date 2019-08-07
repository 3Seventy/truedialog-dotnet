using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

using TrueDialog.Configuration;
using TrueDialog.Exceptions;
using TrueDialog.Helpers;
using TrueDialog.Model;
using TrueDialog.Retry;

namespace TrueDialog
{
    internal class InternalClient
    {
        #region Private Members
        private IRestClient RestClient;
        private TrueDialogConfigSection Config { get; set; }
        private IRetryPolicy RetryPolicy { get; set; }
        private HttpBasicAuthenticator m_userAuthenticator;
        private HttpBasicAuthenticator m_apiAuthenticator;
        #endregion

        public InternalClient(int accountId = 0, string username = null, string password = null)
        {
            Config = TrueDialogConfigSection.GetConfig();
            AccountId = accountId;

            if (AccountId == 0)
                AccountId = Config.Authorization.AccountId;

            if (AccountId == 0)
                throw new ArgumentException("Account ID is missing.");

            var strategy = GetRetryStrategy();
            RetryPolicy = new RetryPolicy<RestErrorDetectionStrategy>(strategy);

            RestClient = CreateClient(Config, username, password);
        }

        #region Account ID Management
        internal int AccountId { get; private set; }

        public void SetAccountId(int accountId)
        {
            AccountId = accountId;
        }

        internal int? AsAccountId { get; private set; }

        public void AsAccount(int accountId)
        {
            AsAccountId = accountId;
        }

        public int CurrentAccount()
        {
            if (AsAccountId.HasValue)
                return AsAccountId.Value;
            else
                return AccountId;
        }

        #endregion

        #region Helper methods

        private RetryStrategy GetRetryStrategy()
        {
            var rval = (RetryStrategy)Activator.CreateInstance(Config.RetryPolicy.Type);

            rval.MaxTries = (byte)Config.RetryPolicy.MaxTries;
            rval.MaxInterval = Config.RetryPolicy.MaxInterval;
            rval.MinInterval = Config.RetryPolicy.MinInterval;
            rval.Interval = Config.RetryPolicy.Interval;

            return rval;
        }

        /// <summary>
        /// Returns a new RestClient() object.
        /// </summary>
        private IRestClient CreateClient(IConfiguration config, string username, string password)
        {
            Assembly thisAssembly = Assembly.GetCallingAssembly();
            AssemblyName asmName = thisAssembly.GetName();
            var version = asmName.Version.ToString();

            string user = username ?? config.Authorization.UserName;
            string pass = password ?? config.Authorization.Password;
            m_userAuthenticator = new HttpBasicAuthenticator(user, pass);

            string apiKey = string.IsNullOrEmpty(config.Authorization.ApiKey) ? user : config.Authorization.ApiKey;
            string apiSecret = string.IsNullOrEmpty(config.Authorization.ApiSecret) ? pass : config.Authorization.ApiSecret;
            m_apiAuthenticator = new HttpBasicAuthenticator(apiKey, apiSecret);

            string userAgent = config.UserAgent;

            if (String.IsNullOrWhiteSpace(userAgent))
                userAgent = String.Format("TrueDialog SDK.NET {0}", version);

            var rval = new RestClient
            {
                Authenticator = m_apiAuthenticator,
                BaseUrl = new Uri(config.BaseUrl),
                UserAgent = userAgent,
                Timeout = (int)config.Timeout.TotalMilliseconds
            };

            rval.ClearHandlers();
            rval.AddHandler("application/json", new NewtonsoftSerializer());
            rval.AddHandler("text/json", new NewtonsoftSerializer());

            rval.AddHandler("application/xml", new XmlDeserializer());
            rval.AddHandler("text/xml", new XmlDeserializer());

            return rval;
        }

        #endregion

        #region Request & Response

        internal InternalClient AsUser()
        {
            RestClient.Authenticator = m_userAuthenticator;
            return this;
        }

        internal List<TEntity> GetList<TEntity>(string resourse, object queryParams, bool throwIfEmpty = false)
            where TEntity : class, new()
        {
            IRestRequest request = BuildRequest(Method.GET, resourse, queryParams);
            IRestResponse response = InnerExecute(request);

            return ProcessListResponse<TEntity>(request, response, throwIfEmpty);
        }

        internal List<TEntity> ProcessListResponse<TEntity>(IRestRequest request, IRestResponse response, bool throwIfEmpty)
            where TEntity: class, new()
        {
            if (response == null)
                return null;

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                if (throwIfEmpty)
                {
                    throw new HttpException(string.Format("Empty list response for {0}: {1} {2} {3}",
                        typeof(TEntity).Name,
                        request.Resource,
                        response.StatusCode,
                        response.StatusDescription));
                }

                return new List<TEntity>();
            }

            return response.Deserialize<List<TEntity>>();
        }

        internal TEntity GetItem<TEntity>(string resourse, object queryParams, bool throwIfEmpty = false)
            where TEntity : class, new()
        {
            IRestRequest request = BuildRequest(Method.GET, resourse, queryParams);
            IRestResponse response = InnerExecute(request);

            return ProcessItemResponse<TEntity>(request, response, throwIfEmpty);
        }

        internal TEntity ProcessItemResponse<TEntity>(IRestRequest request, IRestResponse response, bool throwIfEmpty)
            where TEntity : class, new()
        {
            if (response == null)
                return null;

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                if (throwIfEmpty)
                {
                    throw new HttpException(string.Format("Empty response for {0}: {1} {2} {3}",
                        typeof(TEntity).Name,
                        request.Resource,
                        response.StatusCode,
                        response.StatusDescription));
                }

                return default(TEntity);
            }

            return response.Deserialize<TEntity>();
        }

        internal TEntity Add<TEntity>(string resourse, object queryParams, TEntity item)
            where TEntity : class, new()
        {
            IRestRequest request = BuildRequest(Method.POST, resourse, queryParams, item);
            IRestResponse response = InnerExecute(request);

            return ProcessOperationResponse<TEntity>(request, response, "add");
        }

        internal TEntity Update<TEntity>(string resourse, object queryParams, TEntity item)
            where TEntity : class, new()
        {
            IRestRequest request = BuildRequest(Method.PUT, resourse, queryParams, item);
            IRestResponse response = InnerExecute(request);

            return ProcessOperationResponse<TEntity>(request, response, "update");
        }

        internal IRestResponse Delete(string resourse, object queryParams)
        {
            IRestRequest request = BuildRequest(Method.DELETE, resourse, queryParams);
            IRestResponse response = InnerExecute(request);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                throw new HttpException(string.Format("Empty response on delete operation {0}: {1} {2}", 
                    request.Resource, 
                    response.StatusCode, 
                    response.StatusDescription));
            }

            return response;
        }

        internal TEntity ProcessOperationResponse<TEntity>(IRestRequest request, IRestResponse response, string operation)
            where TEntity: class, new()
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                throw new HttpException(string.Format("Empty response on {0} operation {1}: {2} {3} {4}",
                    operation,
                    typeof(TEntity).Name,
                    request.Resource,
                    response.StatusCode,
                    response.StatusDescription));
            }

            return response.Deserialize<TEntity>();
        }

        internal IRestRequest BuildRequest(
            Method method,
            string resourceUrl,
            object resourceUrlParams,
            object requestBody = null,
            object extraHeaders = null,
            string filter = null,
            bool envelope = false)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                resourceUrl += ((resourceUrl.IndexOf('?') != -1) ? "&" : "?") + filter;
            }

            if (envelope)
            {
                resourceUrl += ((resourceUrl.IndexOf('?') != -1) ? "&" : "?") + "env=";
            }

            var request = new RestRequest
            {
                Resource = resourceUrl,
                Method = method,
                RequestFormat = DataFormat.Json,
            };

            if (requestBody != null)
                request.AddBody(requestBody);

            if (extraHeaders != null)
            {
                var headerValues = ObjectHelper.ToDictionary(extraHeaders);

                foreach (var kvp in headerValues)
                {
                    request.AddHeader(kvp.Key, kvp.Value.ToString());
                }
            }

            if (resourceUrlParams != null)
            {
                var routeValues = ObjectHelper.ToDictionary(resourceUrlParams);

                foreach (var value in routeValues)
                {
                    request.AddUrlSegment(value.Key, (value.Value ?? "").ToString());
                }
            }

            return request;
        }

        private IRestResponse SafeExecute(IRestRequest request, Uri resource)
        {
            try
            {
                var res = RestClient.Execute(request);

                if (!res.StatusCode.IsSuccessCode())
                    return HandleErrorResponse(request, res, resource);

                return res;
            }
            finally
            {
                AsAccountId = null;
                RestClient.Authenticator = m_apiAuthenticator;
            }
        }

        internal IRestResponse InnerExecute(IRestRequest request)
        {
            var resource = RestClient.BuildUri(request);

            if (Config.RetryPolicy.Enabled)
            {
                return RetryPolicy.Execute(
                    attempt =>
                    {
                        return SafeExecute(request, resource);
                    });
            }
            else
            {
                return SafeExecute(request, resource);
            }
        }

        /// <summary>
        /// Handles error response conditions.
        /// </summary>
        /// <param name="request">The request that was made</param>
        /// <param name="response">The response we got back</param>
        /// <param name="resource">The URI that we attmped.</param>
        private IRestResponse HandleErrorResponse(
            IRestRequest request,
            IRestResponse response,
            Uri resource)
        {
            if (response.StatusCode == 0)
            {
                /*
                 * There was some sort of error communicationg with the server, and we did not get a response.
                 * 
                 * E.g.: Connection timed out, Connectin Refused, No route, etc.
                 */

                throw new NetworkException(response.ErrorMessage, response.ErrorException);
            }

            string[] contentTypeParts = response.ContentType.Split(';');
            string contentType = contentTypeParts[0];

            switch (contentType)
            {
                case "application/xml":
                case "text/xml":
                case "application/json":
                case "text/json":
                    TryForDetailedErrors(response);
                    TryForSimpleErrors(response);
                    break;

                    //case "text/plain":
                    //case "text/html":
                    //default:
                    //    break;
            }

            var sb = new StringBuilder();

            sb.AppendFormat(
                "Unable to perform {0} on {1}, additionally the error message could not be parsed",
                request.Method,
                resource);

            if (!String.IsNullOrWhiteSpace(response.Content))
            {
                sb.Append(": ");
                sb.Append(response.Content);
            }

            throw new HttpException((int)response.StatusCode, sb.ToString());
        }

        /// <summary>
        /// Attempts to deserialize a list of errors when we received an error response from the HTTP server.
        /// </summary>
        /// <remarks>
        /// Unlike the TryForSimpleErrors this method attempts to pull out more specific details.
        /// </remarks>
        /// <param name="response">The response to parse</param>
        private void TryForDetailedErrors(IRestResponse response)
        {
            List<ErrorDetail> errors = null;

            try
            {
                errors = response.Deserialize<List<ErrorDetail>>();
            }
            catch (Exception /*ex*/)
            {
                // We deliberately throw away the exception

                //s_log.Debug("Unable to deserialize error message details", ex);
            }

            if (errors != null)
                throw new RemoteException(response.StatusCode, errors);
        }

        /// <summary>
        /// Attempts to deserialize a list of errors when we received an error response from the HTTP server.
        /// </summary>
        /// <param name="response">The response to parse</param>
        private void TryForSimpleErrors(IRestResponse response)
        {
            List<string> errorList = null;

            try
            {
                errorList = response.Deserialize<List<string>>();
            }
            catch (Exception /*ex*/)
            {
                // We deliberately throw away the exception

                //s_log.Debug("Unable to deserialize error message details", ex);
            }

            if (errorList != null)
                throw new ValidationException(errorList.FirstOrDefault());
        }

        #endregion
    }
}
