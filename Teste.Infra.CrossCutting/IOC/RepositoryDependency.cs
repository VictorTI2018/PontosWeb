using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Core.Domain.Interfaces;
using Teste.Infra.Data.Repository;

namespace Teste.Infra.CrossCutting.IOC
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryCategoria, RepositoryCategoria>();
            services.AddScoped<IRepositoryProdutos, RepositoryProdutos>();
        }
    }
}
