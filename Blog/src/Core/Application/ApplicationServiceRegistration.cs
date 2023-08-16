using System.Reflection;
using Blog.src.Core.Application.Profiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.src.Core.Application
{
    public static class ApplicationServiceRegistration {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

        }
    }
}