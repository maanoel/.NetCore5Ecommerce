using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CasaDoCodigoDois
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      //services.AddTransient<ICatalogo, Catalogo>();
      //services.AddTransient<IRelatorio, Relatorio>();

      //services.AddScoped<ICatalogo, Catalogo>();
      //services.AddScoped<IRelatorio, Relatorio>();

      var catalogo = new Catalogo();
      services.AddSingleton<ICatalogo>(catalogo);
      services.AddSingleton<IRelatorio>(new Relatorio(catalogo));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
    {
      if(env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      ICatalogo catalogo = serviceProvider.GetService<ICatalogo>();
      IRelatorio relatorio = serviceProvider.GetService<IRelatorio>();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapGet("/", async context =>
              {
                await relatorio.Imprimir(context);
              });
      });
    }
  }
}
