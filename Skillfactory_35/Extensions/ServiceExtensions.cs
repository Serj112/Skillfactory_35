using Skillfactory_35.Data.Repository;

namespace Skillfactory_35.Extensions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddCustomRepository<TEntity, IRepository>(this IServiceCollection services)
                 where TEntity : class
                 where IRepository : class, IRepository<TEntity>
        {
            services.AddScoped<IRepository<TEntity>, IRepository>();

            return services;
        }
    }
}
