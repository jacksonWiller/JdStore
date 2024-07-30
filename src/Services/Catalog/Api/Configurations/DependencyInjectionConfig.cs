using JdMarketplace.Api.Service;
using Microsoft.Extensions.DependencyInjection;

namespace JdStore.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IImagemService, ImagemService>();
        }
    }
}