using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipInfo.Domain.Entities;

namespace ShipInfo.DAL
{
    public class MainEngineConfiguration : IEntityTypeConfiguration<MainEngine>
    {
        public void Configure(EntityTypeBuilder<MainEngine> builder)
        {
            builder
                .HasKey(me => me.Id);

            builder
                .Property(me => me.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(me => me.Ships)
                .WithOne(s => s.MainEngine)
                .HasForeignKey(s => s.MainEngineId);

            builder
                .Property(me => me.MainEngineType)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(me => me.MaxMainEnginePower)
                .IsRequired();

            builder
                .Property(me => me.MaxMainEngineSpeed)
                .IsRequired();
            ;

        }
    }
}