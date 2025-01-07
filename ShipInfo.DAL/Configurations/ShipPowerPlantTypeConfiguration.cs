using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipInfo.Domain.Entities;

namespace ShipInfo.DAL
{
    public class ShipPowerPlantTypeConfiguration : IEntityTypeConfiguration<ShipPowerPlantType>
    {
        public void Configure(EntityTypeBuilder<ShipPowerPlantType> builder)
        {
            builder
                .HasKey(sppt => sppt.Id);

            builder
                .Property(sppt => sppt.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(s => s.Ships)
                .WithOne(sppt => sppt.ShipPowerPlantType)
                .HasForeignKey(sppt => sppt.ShipPowerPlantTypeId);

            builder
                .Property(sppt => sppt.ShipPowerPlantTypeName)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
