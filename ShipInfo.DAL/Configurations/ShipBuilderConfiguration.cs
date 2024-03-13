using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShipInfo.DAL
{
    public class ShipBuilderConfiguration : IEntityTypeConfiguration<ShipBuilder>
    {
        public void Configure(EntityTypeBuilder<ShipBuilder> builder)
        {
            builder
                .HasKey(sb => sb.Id);

            builder
                .Property(sb => sb.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(s => s.Ships)
                .WithOne(sb => sb.ShipBuilder)
                .HasForeignKey(sb => sb.ShipBuilderId);

            builder
                .Property(sb => sb.ShipBuilderName)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
