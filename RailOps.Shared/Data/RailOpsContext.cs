using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RailOps.Shared.Domain.Roster;

namespace RailOps.Shared.Data
{
    public class RailOpsContext : DbContext
    {
        public DbSet<Road> Roads { get; set; }
        public DbSet<RollingStockType> RollingStockTypes { get; set; }
        public DbSet<EngineModel> EngineModels { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<Car> Cars { get; set; }

        public RailOpsContext(DbContextOptions<RailOpsContext> options)
            : base (options)
        {
        }
    }

    public class RailOpsContextFactory : IDesignTimeDbContextFactory<RailOpsContext>
    {
        public RailOpsContext CreateDbContext(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var connString = configuration.GetConnectionString("RailOps");

            var optionsBuilder = new DbContextOptionsBuilder<RailOpsContext>();
            optionsBuilder.UseSqlServer(connString);

            return new RailOpsContext(optionsBuilder.Options);
        }
    }
}
