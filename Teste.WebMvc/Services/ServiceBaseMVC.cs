using System.Net.Http;
using Teste.WebMvc.Services.Interfaces;
using Teste.WebMvc.Utils;

namespace Teste.WebMvc.Services
{
    public class ServiceBaseMVC<TEntity, TKey> : IServiceBaseMVC<TEntity, TKey> where TEntity : class
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private string Url = "";

        public ServiceBaseMVC(string url, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            Url = url;
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            var _client = _httpClientFactory.CreateClient("namedType");
            var response = await _client.GetAsync(Url);
            return await response.ReadContentAsync<List<TEntity>>();
;        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            var _client = _httpClientFactory.CreateClient("namedType");
            var response = await _client.GetAsync($"{Url}/{id}");
            return await response.ReadContentAsync<TEntity>();
        }

        public async Task<TEntity> SaveAsync(TEntity dados)
        {
            var _client = _httpClientFactory.CreateClient("namedType");
            var response = await _client.PostAsJson($"{Url}", dados);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<TEntity>();
            else throw new Exception($"Ocorreu um erro na chamada da API.");
        }

        public async Task<TEntity> UpdateAsync(TEntity dados)
        {
            var _client = _httpClientFactory.CreateClient("namedType");
            var response = await _client.PutAsJson($"{Url}", dados);
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<TEntity>();
            else throw new Exception($"Ocorreu um erro na chamada da API.");
        }
        public async Task<bool> DeleteAsync(TKey id)
        {
            var _client = _httpClientFactory.CreateClient("namedType");
            var response = await _client.DeleteAsync($"{Url}/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAsync<bool>();
            else throw new Exception($"Ocorreu um erro na chamada da API.");
        }
    }
}
