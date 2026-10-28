using Microsoft.Extensions.DependencyInjection;
using SistemaEmisionSegurosAuto.Interfaces;
using SistemaEmisionSegurosAuto.Repositorios;
using SistemaEmisionSegurosAuto.Servicios;

namespace SistemaEmisionSegurosAuto.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<ICoberturaRepository, CoberturaRepository>();
            services.AddScoped<ICoberturaService, CoberturaService>();

            services.AddScoped<IPolizaRepository, PolizaRepository>();
            services.AddScoped<IPolizaService, PolizaService>();

            return services;
        }
    }
}
