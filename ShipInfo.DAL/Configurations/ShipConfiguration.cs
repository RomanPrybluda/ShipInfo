using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShipInfo.DAL
{
    public class ShipConfiguration : IEntityTypeConfiguration<Ship>
    {
        public void Configure(EntityTypeBuilder<Ship> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Id)
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAdd();

            builder
                .HasOne(e => e.ShipHull)
                .WithOne(ed => ed.Ship)
                .HasForeignKey<Ship>(ed => ed.ShipHullId);

            builder
                .Property(s => s.ShipName)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(s => s.ImoNumber)
                .IsRequired()
                .HasPrecision(7);

            builder.Property(s => s.DateOfBuild)
               .IsRequired();

            builder.Property(s => s.GrossTonnage)
               .IsRequired();

            builder.Property(s => s.SummerDeadweight)
               .IsRequired();

        }
    }
}