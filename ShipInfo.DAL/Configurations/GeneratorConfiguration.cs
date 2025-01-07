using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipInfo.Domain.Entities;

namespace ShipInfo.DAL
{
    public class GeneratorConfiguration : IEntityTypeConfiguration<Generator>
    {
        public void Configure(EntityTypeBuilder<Generator> builder)
        {
            builder
                .HasKey(g => g.Id);

            builder
                .Property(g => g.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(s => s.Ships)
                .WithOne(g => g.Generator)
                .HasForeignKey(g => g.GeneratorId);

            builder
                .Property(g => g.GeneratorType)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(g => g.MaxGeneratorPower)
                .IsRequired();

            builder
                .Property(g => g.GeneratorVoltage)
                .IsRequired();

        }
    }
}
