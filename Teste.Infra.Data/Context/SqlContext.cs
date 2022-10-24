using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Core.Domain.Entities;

namespace Teste.Infra.Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Produtos> Produtos { get; set; }
    }
}
