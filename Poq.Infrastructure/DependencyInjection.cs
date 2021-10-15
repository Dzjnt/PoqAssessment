using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poq.Application.Common.Interfaces;
using Poq.Infrastructure.HTTP;
using Poq.Infrastructure.Services;
using System;

namespace Poq.Infrastructure
{
    public static class DependencyInjection
    {
        public static void InfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<MockyClient>("MockyClient", cfg =>
              {
                  cfg.BaseAddress = new Uri($"{configuration.GetSection("MockyApiUrl").Value}");
                  cfg.DefaultRequestHeaders.Add("primaryKey", $"{configuration.GetSection("MockyApiPrimaryKey").Value}");
                  cfg.DefaultRequestHeaders.Add("secondaryKey", $"{configuration.GetSection("MockyApiSecondaryKey").Value}");
              });
            services.AddTransient<IProductsService, ProductsService>();
        }
    }
}
