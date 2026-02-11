namespace Gestionale.WebApp.ApiClient
{
    public interface IApiClient
    {
        Task<List<T>> GetAllAsync<T>(string endpoint);
        Task<T?> GetByIdAsync<T>(string endpoint, Guid id);

        Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data);
        Task PutAsync<TRequest>(string endpoint, Guid id, TRequest data);
        Task DeleteAsync(string endpoint, Guid id);
    }
}
