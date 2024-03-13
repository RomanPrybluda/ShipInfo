using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShipInfo.DAL
{
    public class ClassSocietyConfiguration : IEntityTypeConfiguration<ClassSociety>
    {
        public void Configure(EntityTypeBuilder<ClassSociety> builder)
        {
            builder
                .HasKey(cs => cs.Id);

            builder
                .Property(cs => cs.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(me => me.Ships)
                .WithOne(cs => cs.ClassSociety)
                .HasForeignKey(cs => cs.ClassSocietyId);

            builder
                .Property(cs => cs.ClassSocietyName)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(cs => cs.ClassSocietyIsIACS)
                .IsRequired();

        }
    }
}