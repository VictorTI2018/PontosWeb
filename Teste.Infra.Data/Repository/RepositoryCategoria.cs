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
    public class RepositoryCategoria: RepositoryBase<Categoria,int>, IRepositoryCategoria
    {
        private readonly SqlContext _sqlContext;
        public RepositoryCategoria(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
