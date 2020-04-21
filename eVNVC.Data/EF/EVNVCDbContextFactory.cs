using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Pomelo.EntityFrameworkCore.MySql;

namespace eVNVC.Data.EF
{
    public class EVNVCDbContextFactory : IDesignTimeDbContextFactory<EVNVCDbContext>
    {
        public EVNVCDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("eVNVCDb");

            var optionsBuilder = new DbContextOptionsBuilder<EVNVCDbContext>();
            optionsBuilder.UseMySql(connectionString);

            return new EVNVCDbContext(optionsBuilder.Options);
        }
    }
}
