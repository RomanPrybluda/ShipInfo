using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShipInfo.DAL.Configurations
{
    public class ShipPropulsorTypeConfiguration : IEntityTypeConfiguration<ShipPropulsorType>
    {
        public void Configure(EntityTypeBuilder<ShipPropulsorType> builder)
        {
            builder
                .HasKey(spt => spt.Id);

            builder
                .Property(spt => spt.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(s => s.Ships)
                .WithOne(spt => spt.ShipPropulsorType)
                .HasForeignKey(spt => spt.ShipPropulsorTypeId);

            builder
                .Property(spt => spt.ShipPropulsorTypeName)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}