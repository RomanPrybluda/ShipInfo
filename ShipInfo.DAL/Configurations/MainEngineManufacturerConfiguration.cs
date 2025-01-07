using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipInfo.Domain.Entities;

namespace ShipInfo.DAL
{
    public class MainEngineManufacturerConfiguration : IEntityTypeConfiguration<MainEngineManufacturer>
    {
        public void Configure(EntityTypeBuilder<MainEngineManufacturer> builder)
        {
            builder
                .HasKey(mem => mem.Id);

            builder
                .Property(mem => mem.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(me => me.MainEngines)
                .WithOne(mem => mem.MainEngineManufacturer)
                .HasForeignKey(mem => mem.MainEngineManufacturerId);

            builder
                .Property(mem => mem.MainEngineManufacturerName)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}