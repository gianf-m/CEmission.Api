using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.EntityFramework {
    public static class ApiDbContextConfig {
        public static IServiceCollection ConfigureServices(this IServiceCollection service, IConfiguration Configuration) {
            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "CEmission.Api", "CEmission.Api");


            Configuration = new ConfigurationBuilder()
               .SetBasePath(Path.GetDirectoryName(filePath))
               .AddJsonFile("appSettings.json")
               .Build();

            service.AddDbContext<ApiDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("Default")));

            return service;
        }
    }
}
