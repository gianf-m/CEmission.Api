﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using MySql.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.EntityFramework {
    public class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext> {
        public ApiDbContextFactory() {

        }

        private readonly IConfiguration Configuration;
        public ApiDbContextFactory(IConfiguration configuration) {
            Configuration = configuration;
        }

        public ApiDbContext CreateDbContext(string[] args) {

            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "CEmission.Api", "CEmission.Api");
                
            IConfiguration Configuration = new ConfigurationBuilder()
               .SetBasePath(Path.GetDirectoryName(filePath))
               .AddJsonFile("appSettings.json")
               .Build();


            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
            optionsBuilder.UseMySQL(Configuration.GetConnectionString("Default"));

            return new ApiDbContext(optionsBuilder.Options);
        }
    }
}
