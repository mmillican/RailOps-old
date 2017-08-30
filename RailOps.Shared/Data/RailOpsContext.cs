using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=RailOps.db");
        }
    }
}
