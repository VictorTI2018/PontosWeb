using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Core.Domain.Entities;

namespace Teste.Core.Domain.Interfaces.Services
{
    public interface IServiceProdutos: IServiceBase<Produtos, int>
    {
        Task<IEnumerable<Produtos>> GetProdutosPorCategoria(int categoriaId);
    }
}
