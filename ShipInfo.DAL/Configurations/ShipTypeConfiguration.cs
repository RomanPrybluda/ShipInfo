using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipInfo.Domain.Entities;

namespace ShipInfo.DAL
{
    public class ShipTypeConfiguration : IEntityTypeConfiguration<ShipType>
    {
        public void Configure(EntityTypeBuilder<ShipType> builder)
        {
            builder
                .HasKey(st => st.Id);

            builder
                .Property(st => st.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(s => s.Ships)
                .WithOne(st => st.ShipType)
                .HasForeignKey(st => st.ShipTypeId);

            builder
                .Property(st => st.ShipTypeName)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}