using CO2.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CO2.DbMigrator {
    public static class Migrator {
        public static IHost MigrateDatabase(this IHost host) {
            using (var scope = host.Services.CreateScope()) {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>()) {
                    try {
                        appContext.Database.Migrate();
                    } catch (Exception ex) {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
