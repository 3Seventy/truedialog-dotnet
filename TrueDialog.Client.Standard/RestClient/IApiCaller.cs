using System.Threading.Tasks;

namespace TrueDialog
{
    internal interface IApiCaller
    {
        void SetSource(string source);

        IApiCaller AsUser();

        int AccountId { get; set; }

        T Get<T>(string url, bool throwIfEmpty = false, object oData = null);

        Task<T> GetAsync<T>(string url, bool throwIfEmpty = false, object oData = null);

        T Post<T>(string url, T data, object oData = null);

        Task<T> PostAsync<T>(string url, T data, object oData = null);

        T Post<T>(string url, object data, object oData = null);

        Task<T> PostAsync<T>(string url, object data, object oData = null);

        T Put<T>(string url, T data);

        Task<T> PutAsync<T>(string url, T data);

        T Put<T>(string url, object data);

        Task<T> PutAsync<T>(string url, object data);

        void Delete(string url);

        Task DeleteAsync(string url);

        (string contentType, byte[] content) Download(string url);

        Task<(string contentType, byte[] content)> DownloadAsync(string url);

        Task<T> UploadAsync<T>(string url, byte[] bytes, string contentType, string fileName);

        T Upload<T>(string url, byte[] bytes, string contentType, string fileName);
    }
}
