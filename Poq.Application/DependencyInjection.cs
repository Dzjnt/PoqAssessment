using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Poq.Application.Common.Behaviours;
using Poq.Application.Common.Mappings;
using Poq.Application.Handlers;
using System.Reflection;

namespace Poq.Application
{
    public static class DependencyInjection
    {
        public static void ApplicationRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(GetProductsQueryHandler).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        }
    }
}
