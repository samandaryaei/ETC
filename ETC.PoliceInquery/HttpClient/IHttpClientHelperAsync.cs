﻿using ETC.PoliceInquery.Models.DTOs.Request;
using ETC.PoliceInquery.Models.DTOs.Response;

namespace ETC.PoliceInquery.HttpClient
{
    public interface IHttpClientHelperAsync
    {
        Task<TResponse> GetAsync<TResponse>(string url, Dictionary<string, string> queryParam, bool hasAuthHeader = false)
            where TResponse : BaseResponseDto;
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest body, bool hasAuthHeader = false) 
            where TRequest : BaseRequestDto 
            where TResponse : BaseResponseDto;
        Task<string> PutAsync(string url, bool hasAuthHeader = false) => throw new NotImplementedException();
        Task<string> DeleteAsync(string url, bool hasAuthHeader = false) => throw new NotImplementedException();
        Task<string> PatchAsync(string url, bool hasAuthHeader = false) => throw new NotImplementedException();
    }
}
