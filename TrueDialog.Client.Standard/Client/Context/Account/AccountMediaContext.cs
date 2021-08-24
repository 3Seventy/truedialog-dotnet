using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class AccountMediaContext : BaseContext, IAccountMediaContext
    {
        internal AccountMediaContext(IApiCaller api) : base(api)
        {
        }

        public MediaContent GetMediaContent(string mediaId)
        {
            var (contentType, content) = Api.Download($"/media/{mediaId}");

            return new MediaContent
            {
                Content = content,
                ContentType = contentType
            };
        }

        public List<AccountMedia> GetList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<AccountMedia>>($"/account/{accountId}/image", throwIfEmpty);
        }

        public List<AccountMedia> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public AccountMedia GetById(int accountId, int imageId, bool throwIfEmpty = false)
        {
            return Api.Get<AccountMedia>($"/account/{accountId}/image/{imageId}", throwIfEmpty);
        }

        public AccountMedia GetById(int imageId, bool throwIfEmpty = false)
        {
            return GetById(CurrentAccount, imageId, throwIfEmpty);
        }

        public AccountMedia UploadAsByteArray(MediaType type, byte[] byteArray)
        {
            return UploadAsByteArray(CurrentAccount, type, byteArray);
        }

        public AccountMedia UploadAsByteArray(string extension, byte[] byteArray)
        {
            return UploadAsByteArray(CurrentAccount, TypeFromExtension(extension), byteArray);
        }

        public AccountMedia UploadAsByteArray(int accountId, MediaType type, byte[] byteArray)
        {
            var extension = ExtensionFromMimeType(type);
            var fileName = String.Format("ACCT{0}_{1}_Media{2}", accountId, DateTime.UtcNow.Ticks, extension);
            var contentType = ContentTypeFromMime(type);

            var rval = Api.Upload<List<AccountMedia>>($"/account/{accountId}/image", byteArray, contentType, fileName);
            return rval.FirstOrDefault();
        }

        public AccountMedia UploadAsBase64(int accountId, string base64String)
        {
            var extension = ExtensionFromMimeType(base64String);
            var type = TypeFromExtension(extension);
            var bytes = BytesFromBase64String(base64String);

            return UploadAsByteArray(accountId, type, bytes);
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

        private string ContentTypeFromMime(MediaType type)
        {
            switch (type)
            {
                case MediaType.ImageGif:
                    return "image/gif";
                case MediaType.ImageJpg:
                    return "image/jpg";
                case MediaType.ImagePng:
                    return "image/png";
            }

            return "";
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

        private MediaType TypeFromExtension(string extension)
        {
            switch(extension)
            {
                case ".gif":
                    return MediaType.ImageGif;
                case ".png":
                    return MediaType.ImagePng;
                case ".jpg":
                case ".jpeg":
                    return MediaType.ImageJpg;
                default:
                    throw new ArgumentException(String.Format("{0} is not supported extension.", extension));
            }
        }

        public void Delete(int accountId, int imageId)
        {
            Api.Delete($"/account/{accountId}/image/{imageId}");
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
