using System.Threading.Tasks;

namespace WillBeEnterprise.Services.Http
{
    public interface IHttpService
    {
        Task<T> ExecuteGetRequest<T>(string url);
        Task ExecutePostRequest<T>(string url, T data);
        Task ExecutePutRequest<T>(string url, T data);
    }
}
