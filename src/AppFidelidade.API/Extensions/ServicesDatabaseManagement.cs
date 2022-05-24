using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppFidelidade.API.Extensions;

public static class ServicesDatabaseManagement
{
         
    public static void MigrationInitialisation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        serviceScope.ServiceProvider.GetService<DbContext>()?.Database.Migrate();
    }
}