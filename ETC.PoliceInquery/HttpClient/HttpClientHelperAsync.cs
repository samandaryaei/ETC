using ETC.PoliceInquery.Models.DTOs.Request;
using ETC.PoliceInquery.Models.DTOs.Response;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace ETC.PoliceInquery.HttpClient
{
    public class HttpClientHelperAsync : IHttpClientHelperAsync
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HttpClientHelperAsync> _logger;

        public HttpClientHelperAsync(IHttpClientFactory httpClientFactory, ILogger<HttpClientHelperAsync> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<TResponse> GetAsync<TResponse>(string url, Dictionary<string, string> queryParam, bool hasAuthHeader = false) 
            where TResponse : BaseResponseDto
        {
            using var httpClient = _httpClientFactory.CreateClient("ETC");
            var fullUrl = $"{httpClient.BaseAddress}{url}";
            var destUrl = queryParam is not null ? QueryHelpers.AddQueryString(fullUrl, queryParam) : fullUrl;
            var responseStr = await httpClient.GetAsync(destUrl).Result.Content.ReadAsStringAsync();
            var objDeserializeObject = JsonConvert.DeserializeObject<TResponse>(responseStr);
            return objDeserializeObject;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest body, bool hasAuthHeader = false)
            where TRequest : BaseRequestDto
            where TResponse : BaseResponseDto
        {
            var bodySerialize = JsonConvert.SerializeObject(body);
            var requestContent = new StringContent(bodySerialize, Encoding.UTF8, "application/json");
            using var httpClient = _httpClientFactory.CreateClient("ETC");
            var response = await httpClient.PostAsync($"{httpClient.BaseAddress}{url}", requestContent);
            response.EnsureSuccessStatusCode();
            var responseStr = await response.Content.ReadAsStringAsync();
            var objDeserializeObject = JsonConvert.DeserializeObject<TResponse>(responseStr);
            return objDeserializeObject;
        }
    }
}
