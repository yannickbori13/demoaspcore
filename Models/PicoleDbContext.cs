using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Picole.WebApi.Models
{
    public class PicoleDbContext:DbContext
    {
        public DbSet<Fermentable> Fermentables { get; set; }
        public DbSet<Hops> Hops { get; set; }
        public DbSet<Yeast> Yeasts { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UseType> UseTypes { get; set; }
        public DbSet<SensorLog> SensorLogs { get; set; }
        public DbSet<FermenterChamberConfiguration> FermenterChamberConfigurations { get; set; }

        public PicoleDbContext(DbContextOptions<PicoleDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>()
                .HasMany(u => u.Extras)
                .WithOne(e => e.Unit);

        }
    }
}
