using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzariaUDS.Business;
using PizzariaUDS.Context;
using PizzariaUDS.Exceptions;
using PizzariaUDS.Repository;

namespace PizzariaUDS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PizzariaContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));
            services.AddScoped<SaborRepository>();
            services.AddScoped<TamanhoRepository>();
            services.AddScoped<PizzaRepository>();
            services.AddScoped<PersonalizacaoRepository>();
            services.AddScoped<PedidoPizzaBusiness>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(PizzriaUDSCustomExceptionFilter));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            // carga inicial de dados
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PizzariaContext>();
            new SaborRepository(context).SetarSabores();
            new TamanhoRepository(context).SetarTamanhos();
            new PersonalizacaoRepository(context).SetarPersonalizacoes();
        }
    }
}
