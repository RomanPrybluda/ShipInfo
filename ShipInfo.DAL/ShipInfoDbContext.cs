using Microsoft.EntityFrameworkCore;
using ShipInfo.Domain.Entities;

namespace ShipInfo.DAL
{
    public class ShipInfoDbContext : DbContext
    {
        public ShipInfoDbContext(DbContextOptions options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Ship> Ships { get; set; }

        public DbSet<ShipType> ShipTypes { get; set; }

        public DbSet<ShipPowerPlantType> ShipPowerPlantTypes { get; set; }

        public DbSet<ShipPropulsorType> ShipPropulsorTypes { get; set; }

        public DbSet<MainEngine> MainEngines { get; set; }

        public DbSet<AuxiliaryEngine> AuxiliaryEngines { get; set; }

        public DbSet<Generator> Generators { get; set; }

        public DbSet<ShipFlag> ShipFlags { get; set; }

        public DbSet<ShipStatus> Statuses { get; set; }

        public DbSet<ClassSociety> ClassSocieties { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Operator> Operators { get; set; }

        public DbSet<ShipBuilder> ShipBuilders { get; set; }

        public DbSet<MainEngineManufacturer> MainEngineManufacturers { get; set; }

        public DbSet<AuxiliaryEngineManufacturer> AuxiliaryEngineManufacturers { get; set; }

        public DbSet<GeneratorManufacturer> GeneratorManufacturers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ShipInfoDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}