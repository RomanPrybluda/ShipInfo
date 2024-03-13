using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShipInfo.DAL
{
    public class AuxiliaryEngineManufacturerConfiguration : IEntityTypeConfiguration<AuxiliaryEngineManufacturer>
    {
        public void Configure(EntityTypeBuilder<AuxiliaryEngineManufacturer> builder)
        {
            builder
                .HasKey(aem => aem.Id);

            builder
                .Property(aem => aem.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(ae => ae.AuxiliaryEngines)
                .WithOne(aem => aem.AuxiliaryEngineManufacturer)
                .HasForeignKey(e => e.AuxiliaryEngineManufacturerId);

            builder
                .Property(aem => aem.AuxiliaryEngineManufacturerName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}