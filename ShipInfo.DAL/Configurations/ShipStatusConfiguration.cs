using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipInfo.Domain.Entities;

namespace ShipInfo.DAL
{
    public class ShipStatusConfiguration
    {
        public void Configure(EntityTypeBuilder<ShipStatus> builder)
        {
            builder
                .HasKey(sts => sts.Id);

            builder
                .Property(sts => sts.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(s => s.Ships)
                .WithOne(st => st.ShipStatus)
                .HasForeignKey(st => st.StatusId);

            builder
                .Property(sts => sts.StatusName)
                .IsRequired()
                .HasMaxLength(30);

        }
    }
}