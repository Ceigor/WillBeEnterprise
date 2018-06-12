using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WillBeEnterprise.Services.Http
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient HttpClient;

        public HttpService()
        {
            HttpClient = new HttpClient();
        }

        public async Task<T> ExecuteGetRequest<T>(string url)
        {
            var response = HttpClient.GetAsync(new Uri(url)).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseData);
            }
            else
                throw new HttpRequestException();
        }

        public Task ExecutePostRequest<T>(string url, T data)
        {
            throw new System.NotImplementedException();
        }

        public Task ExecutePutRequest<T>(string url, T data)
        {
            throw new System.NotImplementedException();
        }
    }
}
