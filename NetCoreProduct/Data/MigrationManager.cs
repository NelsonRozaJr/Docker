using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NetCoreProduct.Data
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
                {
                    try
                    {
                        appDbContext.Database.Migrate();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return host;
        }
    }
}