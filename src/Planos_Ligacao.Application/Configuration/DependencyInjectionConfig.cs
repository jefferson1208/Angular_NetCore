using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using PlanosLigacao.Domain.Interfaces.Repository;
using PlanosLigacao.Domain.Interfaces.Services;
using PlanosLigacao.Domain.Notifications;
using PlanosLigacao.Domain.Services;
using PlanosLigacao.Infra.Data.Context;
using PlanosLigacao.Infra.Data.Repository.Planos;

namespace PlanosLigacao.Application.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<PlanosLigacaoContext>();
            services.AddScoped<IPlanoRepository, PlanoRepository>();
            services.AddScoped<ICustoPlanoRepository, CustoPlanoRepository>();
            services.AddScoped<IPlanoService, PlanoService>();
            services.AddScoped<ICustoPlanoService, CustoPlanoService>();
            services.AddScoped<INotificador, Notificador>();

            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
