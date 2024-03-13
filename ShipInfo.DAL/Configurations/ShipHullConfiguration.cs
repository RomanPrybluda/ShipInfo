using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShipInfo.DAL.Configurations
{
    public class ShipHullConfiguration : IEntityTypeConfiguration<ShipHull>
    {
        public void Configure(EntityTypeBuilder<ShipHull> builder)
        {
            builder
                .HasKey(sh => sh.Id);

            builder
                .Property(sh => sh.Id)
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAdd();

            builder
                .HasOne(s => s.Ship)
                .WithOne(sh => sh.ShipHull);
        }
    }
}