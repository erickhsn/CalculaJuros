using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.API.ClientRequest
{
    public class HttpClientRequest
    {
        protected readonly HttpClient _httpClient;
        private const string BASE_URL = "https://run.mocky.io/v3/";

        public HttpClientRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetRequest(string url)
        {
            string endpoint = BASE_URL + url;

            HttpResponseMessage response = _httpClient.GetAsync(endpoint).Result;

            if (!response.IsSuccessStatusCode)
                throw new ArgumentException($"The {endpoint} fails and returns the following status code: " + response.StatusCode);

            return await response.Content.ReadAsStringAsync();
        }

    }
}
