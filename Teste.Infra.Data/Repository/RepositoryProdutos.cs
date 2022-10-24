using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Core.Domain.Entities;
using Teste.Core.Domain.Interfaces;
using Teste.Infra.Data.Context;

namespace Teste.Infra.Data.Repository
{
    public class RepositoryProdutos: RepositoryBase<Produtos, int>, IRepositoryProdutos
    {
        private readonly SqlContext _sqlContext;

        public RepositoryProdutos(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<IEnumerable<Produtos>> GetProdutosPorCategoria(int categoriaId) => await _sqlContext.Produtos.Where(x => x.CategoriaId == categoriaId).ToListAsync();
    }
}
