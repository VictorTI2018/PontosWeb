using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Core.Domain.Entities;
using Teste.Core.Domain.Interfaces;
using Teste.Core.Domain.Interfaces.Services;

namespace Teste.Services
{
    public class ServiceProdutos: ServiceBase<Produtos, int>, IServiceProdutos
    {

        private readonly IRepositoryProdutos _repoProdutos;

        public ServiceProdutos(IRepositoryProdutos repoProdutos) : base(repoProdutos)
        {
            _repoProdutos = repoProdutos;
        }

        public async Task<IEnumerable<Produtos>> GetProdutosPorCategoria(int categoriaId) => await _repoProdutos.GetProdutosPorCategoria(categoriaId);
    }
}
