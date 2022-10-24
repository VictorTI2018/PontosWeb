using Teste.Core.Domain.Entities;
using Teste.WebMvc.Services.Interfaces;

namespace Teste.WebMvc.Services
{
    public class ServiceProdutosMVC : ServiceBaseMVC<Produtos, int>, IServiceProdutosMVC
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ServiceProdutosMVC(IHttpClientFactory httpClientFactory) : base("/api/produtos", httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
