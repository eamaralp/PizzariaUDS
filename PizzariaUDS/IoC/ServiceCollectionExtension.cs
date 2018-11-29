using Microsoft.Extensions.DependencyInjection;
using PizzariaUDS.Business;
using PizzariaUDS.Repository;

namespace PizzariaUDS.IoC
{
    public static class InjetadorDepe2ndencias
    {
        public static IServiceCollection InjetarDependencias(this IServiceCollection services)
        {
            InjetarRepositorios(services);
            InjetarBusiness(services);

            return services;
        }
        
        private static void InjetarRepositorios(IServiceCollection services)
        {
            services.AddScoped<SaborRepository>();
            services.AddScoped<TamanhoRepository>();
            services.AddScoped<PizzaRepository>();
            services.AddScoped<PersonalizacaoRepository>();
            services.AddScoped<PedidoRepository>();
        }

        private static void InjetarBusiness(IServiceCollection services)
        {
            services.AddScoped<PedidoPizzaBusiness>();
            services.AddScoped<PizzaBusiness>();
        }
    }
}