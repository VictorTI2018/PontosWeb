using Microsoft.Extensions.DependencyInjection;
using Teste.Core.Domain.Interfaces.Services;
using Teste.Services;

namespace Teste.Infra.CrossCutting.IOC
{
    public static class ServiceDependency
    {

        public static void AddServicesDependency(this IServiceCollection services)
        {
            services.AddScoped<IServiceCategoria, ServiceCategoria>();
            services.AddScoped<IServiceProdutos, ServiceProdutos>();
        }
    }
}
