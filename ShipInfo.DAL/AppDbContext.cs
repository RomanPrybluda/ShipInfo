using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL.Configurations;

namespace ShipInfo.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Ship> Ships { get; set; }

        public DbSet<ShipType> ShipTypes { get; set; }

        public DbSet<ShipHull> ShipHulls { get; set; }

        public DbSet<ShipPowerPlantType> ShipPowerPlantTypes { get; set; }

        public DbSet<ShipPropulsorType> ShipPropulsorTypes { get; set; }

        public DbSet<MainEngine> MainEngines { get; set; }

        public DbSet<AuxiliaryEngine> AuxiliaryEngines { get; set; }

        public DbSet<Generator> Generators { get; set; }

        public DbSet<ShipFlag> ShipFlags { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<ClassSociety> ClassSocieties { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Operator> Operators { get; set; }

        public DbSet<ShipBuilder> ShipBuilders { get; set; }

        public DbSet<MainEngineManufacturer> MainEngineManufacturers { get; set; }

        public DbSet<AuxiliaryEngineManufacturer> AuxiliaryEngineManufacturers { get; set; }

        public DbSet<GeneratorManufacturer> GeneratorManufacturers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ShipConfiguration().Configure(modelBuilder.Entity<Ship>());

            new ShipTypeConfiguration().Configure(modelBuilder.Entity<ShipType>());

            new ShipHullConfiguration().Configure(modelBuilder.Entity<ShipHull>());

            new ShipPowerPlantTypeConfiguration().Configure(modelBuilder.Entity<ShipPowerPlantType>());

            new ShipPropulsorTypeConfiguration().Configure(modelBuilder.Entity<ShipPropulsorType>());

            new MainEngineConfiguration().Configure(modelBuilder.Entity<MainEngine>());

            new AuxiliaryEngineConfiguration().Configure(modelBuilder.Entity<AuxiliaryEngine>());

            new GeneratorConfiguration().Configure(modelBuilder.Entity<Generator>());

            new ShipFlagConfiguration().Configure(modelBuilder.Entity<ShipFlag>());

            new StatusConfiguration().Configure(modelBuilder.Entity<Status>());

            new ClassSocietyConfiguration().Configure(modelBuilder.Entity<ClassSociety>());

            new OwnerConfiguration().Configure(modelBuilder.Entity<Owner>());

            new OperatorConfiguration().Configure(modelBuilder.Entity<Operator>());

            new ShipBuilderConfiguration().Configure(modelBuilder.Entity<ShipBuilder>());

            new MainEngineManufacturerConfiguration().Configure(modelBuilder.Entity<MainEngineManufacturer>());

            new AuxiliaryEngineManufacturerConfiguration().Configure(modelBuilder.Entity<AuxiliaryEngineManufacturer>());

            new GeneratorManufacturerConfiguration().Configure(modelBuilder.Entity<GeneratorManufacturer>());

            base.OnModelCreating(modelBuilder);

        }
    }
}