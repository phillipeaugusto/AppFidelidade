using AppFidelidade.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppFidelidade.API.Extensions
{
    public static class ServicesDataBaseExtension
    {
        public static void ServicesDataBaseInitialization(this IServiceCollection services, IConfiguration configuration)
        {
            var mySqlConnectionStr = configuration["ConnectionMySql:ConnectionString"];
            services.AddDbContext<DataContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
        }
    }
}