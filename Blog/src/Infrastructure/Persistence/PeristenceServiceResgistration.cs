using Blog.src.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Blog.src.Core.Application.Persistance.Contracts;
using Blog.src.Infrastructure.Persistance.Repositories;


namespace Blog.src.Core.Application.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("BlogCOnfigurationString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            
            return services;
        }
    }
}
