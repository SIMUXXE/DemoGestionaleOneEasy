namespace Gestionale.WebApp.ApiClient
{
    using System.Net;
    using System.Net.Http.Json;
    using System.Text.Json;

    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<T>> GetAllAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            await EnsureSuccess(response);

            var result = await response.Content.ReadFromJsonAsync<List<T>>(_jsonOptions);
            return result ?? new List<T>();
        }

        public async Task<T?> GetByIdAsync<T>(string endpoint, Guid id)
        {
            var response = await _httpClient.GetAsync($"{endpoint}/{id}");
            await EnsureSuccess(response);

            return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, data, _jsonOptions);
            await EnsureSuccess(response);

            return await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions);
        }

        public async Task PutAsync<TRequest>(string endpoint, Guid id, TRequest data)
        {
            var response = await _httpClient.PutAsJsonAsync($"{endpoint}/{id}", data, _jsonOptions);
            await EnsureSuccess(response);
        }

        public async Task DeleteAsync(string endpoint, Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{endpoint}/{id}");
            await EnsureSuccess(response);
        }

        private static async Task EnsureSuccess(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;

            var content = await response.Content.ReadAsStringAsync();

            throw new ApplicationException($"API Error: {(int)response.StatusCode} - {response.StatusCode} \n{content}");
        }
    }
}
