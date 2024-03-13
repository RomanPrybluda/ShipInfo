using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShipInfo.DAL
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder
                .HasKey(ow => ow.Id);

            builder
                .Property(ow => ow.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(s => s.Ships)
                .WithOne(ow => ow.Owner)
                .HasForeignKey(ow => ow.OwnerId);

            builder
                .Property(st => st.OwnerName)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}