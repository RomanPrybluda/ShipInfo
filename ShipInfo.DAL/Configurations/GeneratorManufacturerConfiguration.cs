using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShipInfo.DAL
{
    public class GeneratorManufacturerConfiguration : IEntityTypeConfiguration<GeneratorManufacturer>
    {
        public void Configure(EntityTypeBuilder<GeneratorManufacturer> builder)
        {
            builder
                .HasKey(gm => gm.Id);

            builder
                .Property(gm => gm.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(g => g.Generators)
                .WithOne(gm => gm.GeneratorManufacturer)
                .HasForeignKey(gm => gm.GeneratorManufacturerId);

            builder
                .Property(gm => gm.GeneratorManufacturerName)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}