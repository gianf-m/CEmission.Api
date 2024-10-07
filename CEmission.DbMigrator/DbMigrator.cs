using CEmission.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CEmission.DbMigrator {
    public static class Migrator {
        public static IHost MigrateDatabase(this IHost host) {
            using (var scope = host.Services.CreateScope()) {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>()) {
                    try {
                        appContext.Database.Migrate();
                    } catch (Exception ex) {
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
