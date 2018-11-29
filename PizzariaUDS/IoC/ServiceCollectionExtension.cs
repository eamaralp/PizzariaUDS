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
            services.AddScoped<ISaborRepository,SaborRepository>();
            services.AddScoped<ITamanhoRepository, TamanhoRepository>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IPersonalizacaoRepository, PersonalizacaoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }

        private static void InjetarBusiness(IServiceCollection services)
        {
            services.AddScoped<PedidoPizzaBusiness>();
            services.AddScoped<PizzaBusiness>();
        }
    }
}