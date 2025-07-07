using Cims4.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cims4.UI.Helpers
{
    public static class DbContextHelper
    {
        public static CardinalDbContext CreateContext()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string 'DefaultConnection' is missing or empty.");

            var options = new DbContextOptionsBuilder<CardinalDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new CardinalDbContext(options);
        }
    }
}
