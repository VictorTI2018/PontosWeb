using Teste.Core.Domain.Entities;
using Teste.Core.Domain.Interfaces;
using Teste.Core.Domain.Interfaces.Services;

namespace Teste.Services
{
    public class ServiceCategoria: ServiceBase<Categoria, int>, IServiceCategoria
    {
        private readonly IRepositoryCategoria _repoCategoria;

        public ServiceCategoria(IRepositoryCategoria repositoryCategoria) : base(repositoryCategoria)
        {

        }
    }
}
