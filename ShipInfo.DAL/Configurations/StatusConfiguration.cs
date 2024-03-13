using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShipInfo.DAL.Configurations
{
    public class StatusConfiguration
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder
                .HasKey(sts => sts.Id);

            builder
                .Property(sts => sts.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(s => s.Ships)
                .WithOne(st => st.Status)
                .HasForeignKey(st => st.StatusId);

            builder
                .Property(sts => sts.StatusName)
                .IsRequired()
                .HasMaxLength(30);

        }
    }
}