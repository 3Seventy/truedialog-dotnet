using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class AccountMediaContext : BaseContext
    {
        internal AccountMediaContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "/account/{accountId}/image";
        private const string ITEM = "/account/{accountId}/image/{imageId}";

        public List<AccountMedia> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<AccountMedia>(LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public List<AccountMedia> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public AccountMedia GetById(int accountId, int imageId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<AccountMedia>(ITEM, new { accountId, imageId }, throwIfEmpty);
            return rval;
        }

        public AccountMedia GetById(int imageId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, imageId, throwIfEmpty);
        }

        public AccountMedia UploadAsByteArray(int accountId, MediaType type, byte[] byteArray)
        {
            var request = TDClient.BuildRequest(Method.POST, LIST, new { accountId });

            var extension = ExtensionFromMimeType(type);
            var fileName = String.Format("ACCT{0}_{1}_Media{2}", accountId, DateTime.UtcNow.Ticks, extension);

            request.AddFile("media", byteArray, fileName);

            var response = TDClient.InnerExecute(request);

            var rval = TDClient.ProcessListResponse<AccountMedia>(request, response, true);
            return rval.FirstOrDefault();
        }

        public AccountMedia UploadAsBase64(int accountId, string base64String)
        {
            var request = TDClient.BuildRequest(Method.POST, LIST, new { accountId });
            var extension = ExtensionFromMimeType(base64String);
            var fileName = String.Format("ACCT{0}_{1}_Media{2}", accountId, DateTime.UtcNow.Ticks, extension);

            var bytes = BytesFromBase64String(base64String);
            request.AddFile("media", bytes, fileName);

            var response = TDClient.InnerExecute(request);

            var rval = TDClient.ProcessListResponse<AccountMedia>(request, response, true);
            return rval.FirstOrDefault();
        }

        private byte[] BytesFromBase64String(string base64string)
        {
            CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
            int index = compareInfo.IndexOf(base64string, ";base64,", CompareOptions.Ordinal);
            if (index < 0)
            {
                return null;
            }
            var base64clean = base64string.Substring(index + ";base64,".Length);

            return Convert.FromBase64String(base64clean);
        }

        private string ExtensionFromMimeType(string imageString)
        {
            var startIndex = imageString.IndexOf("data:") + "data:".Length;
            var length = imageString.IndexOf(";base64,") - startIndex;
            var mimeType = imageString.Substring(startIndex, length);
            switch (mimeType)
            {
                case "image/jpeg":
                    return ".jpg";
                case "image/gif":
                    return ".gif";
                case "image/png":
                    return ".png";
                default:
                    throw new ArgumentException(String.Format("{0} is not supported MIME type", mimeType));
            }
        }

        private string ExtensionFromMimeType(MediaType type)
        {
            switch (type)
            {
                case MediaType.ImageGif:
                    return ".gif";
                case MediaType.ImagePng:
                    return ".png";
                case MediaType.ImageJpg:
                    return ".jpg";
            }

            return string.Empty;
        }

        public void Delete(int accountId, int imageId)
        {
            TDClient.Delete(ITEM, new { accountId, imageId });
        }

        public void Delete(int imageId)
        {
            Delete(CurrentAccount, imageId);
        }

        public void Delete(AccountMedia media)
        {
            Delete(media.AccountId, media.Id);
        }
    }
}
