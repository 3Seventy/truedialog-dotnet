using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IAccountMediaContext
    {
        MediaContent GetMediaContent(string mediaId);

        List<AccountMedia> GetList(int accountId, bool throwIfEmpty = false);

        List<AccountMedia> GetList(bool throwIfEmpty = false);

        AccountMedia GetById(int accountId, int imageId, bool throwIfEmpty = false);

        AccountMedia GetById(int imageId, bool throwIfEmpty = false);

        AccountMedia UploadAsByteArray(MediaType type, byte[] byteArray);

        AccountMedia UploadAsByteArray(string extension, byte[] byteArray);

        AccountMedia UploadAsByteArray(int accountId, MediaType type, byte[] byteArray);

        AccountMedia UploadAsBase64(int accountId, string base64String);

        void Delete(int accountId, int imageId);

        void Delete(int imageId);

        void Delete(AccountMedia media);
    }
}
