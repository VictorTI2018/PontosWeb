using Teste.Core.Domain.Entities;
using Teste.WebMvc.Services.Interfaces;

namespace Teste.WebMvc.Services
{
    public class ServiceCategoriaMVC: ServiceBaseMVC<Categoria, int>, IServiceCategoriaMVC
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ServiceCategoriaMVC(IHttpClientFactory httpClientFactory) : base("/api/categoria", httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
