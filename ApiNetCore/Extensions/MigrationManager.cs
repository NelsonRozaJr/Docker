﻿using ApiNetCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ApiNetCore.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using var appContext = scope.ServiceProvider.GetRequiredService<CatalogContext>();
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return host;
        }
    }
}
