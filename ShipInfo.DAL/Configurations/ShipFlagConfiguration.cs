using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShipInfo.DAL
{
    public class ShipFlagConfiguration : IEntityTypeConfiguration<ShipFlag>
    {
        public void Configure(EntityTypeBuilder<ShipFlag> builder)
        {
            builder
                .HasKey(sf => sf.Id);

            builder
                .Property(sf => sf.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(s => s.Ships)
                .WithOne(sf => sf.ShipFlag)
                .HasForeignKey(sf => sf.ShipFlagId);

            builder
                .Property(sf => sf.ShipFlagName)
                .IsRequired()
                .HasMaxLength(50);


        }
    }
}