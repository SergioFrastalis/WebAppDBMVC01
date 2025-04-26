namespace WebAppDBMVC01.Repositories
{
    public static class RepositoriesDIExtensions
    {
        public static IServiceCollection AddRepositories( this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
