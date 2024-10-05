using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO2.EntityFramework {
    public static class ApiDbContextConfig {
        public static IServiceCollection ConfigureServices(this IServiceCollection service, IConfiguration Configuration) {
            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "CO2.Api", "CO2.Api");


            Configuration = new ConfigurationBuilder()
               .SetBasePath(Path.GetDirectoryName(filePath))
               .AddJsonFile("appSettings.json")
               .Build();

            service.AddDbContext<ApiDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("Default")));

            //service.AddScoped<IPostulantRepository, PostulantRepository>();

            return service;
        }
    }
}
