using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Core.Domain.Entities;

namespace Teste.Core.Domain.Interfaces
{
    public interface IRepositoryProdutos : IRepositoryBase<Produtos, int>
    {

        Task<IEnumerable<Produtos>> GetProdutosPorCategoria(int categoriaId);
    }
}
