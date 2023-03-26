using App.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Configuration
{
    public static class DatabaseConfig
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
