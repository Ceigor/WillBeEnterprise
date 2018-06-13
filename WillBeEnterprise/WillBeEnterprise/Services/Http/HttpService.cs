using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WillBeEnterprise.Services.Http
{
    public class HttpService : IHttpService
    {

        private enum WithDataRequestType { POST, PUT };

        private readonly HttpClient HttpClient;

        public HttpService()
        {
            HttpClient = new HttpClient();
        }

        public async Task<T> ExecuteGetRequest<T>(string url)
        {
            var response = await HttpClient.GetAsync(new Uri(url));
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task ExecutePostRequest<T>(string url, T data)
        {
            await ExecuteWithJsonDataRequest<T>(WithDataRequestType.POST, url, data);
        }

        public async Task ExecutePutRequest<T>(string url, T data)
        {
            await ExecuteWithJsonDataRequest<T>(WithDataRequestType.PUT, url, data);
        }

        private async Task ExecuteWithJsonDataRequest<T>(WithDataRequestType requestType, string url, T data)
        {
            var content = CreateJsonContent<T>(data);
            HttpResponseMessage response;
            if (requestType == WithDataRequestType.POST)
                response = await HttpClient.PostAsync(url, content);
            else
                response = await HttpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
           await response.Content.ReadAsStringAsync();
        }

        private StringContent CreateJsonContent<T>(T data)
        {
            return new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        }
    }
}
