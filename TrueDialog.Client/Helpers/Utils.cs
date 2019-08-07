using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace TrueDialog.Helpers
{
    public static class Utils
    {
        public static bool IsSuccessCode(this HttpStatusCode code)
        {
            int val = (int)code;
            return (val >= 200) && (val <= 299);
        }

        public static TData Deserialize<TData>(this IRestResponse response)
            where TData : class, new()
        {
            if (String.IsNullOrWhiteSpace(response.Content))
                return default(TData);

            IDeserializer des = null;

            string contentType = response.ContentType.ToLower();
            contentType = contentType.Split(new char[] { ';' }).FirstOrDefault().Trim();

            switch (contentType)
            {
                case "application/json":
                case "text/json":
                    des = new JsonDeserializer();
                    break;

                case "application/xml":
                case "text/xml":
                    des = new XmlDeserializer();
                    break;

                default:
                    // TODO: Log this condition
                    return default(TData);
            }

            return des.Deserialize<TData>(response);
        }

        internal static string SoftReadPhoneNumber(string phoneNumber)
        {
            var rval = RemoveSpecialCharacters(phoneNumber);

            if (rval[0] == '1' && rval.Length == 11)
                return rval;
            else if (rval[0] != '1' && rval.Length == 10)
                rval = "1" + rval;
            else
                throw new ArgumentException("Wrong phone number format. Please follow E.164 format (+1xxxxxxxxxx).");

            return rval;
        }

        internal static string ReadPhoneNumber(string phoneNumber)
        {
            var rval = RemoveSpecialCharacters(phoneNumber);

            if (rval[0] == '1' && rval.Length == 11)
                rval = "+" + rval;
            else if (rval[0] != '1' && rval.Length == 10)
                rval = "+1" + rval;
            else
                throw new ArgumentException("Wrong phone number format. Please follow E.164 format (+1xxxxxxxxxx).");

            return rval;
        }

        internal static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if (c >= '0' && c <= '9')
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
