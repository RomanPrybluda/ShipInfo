using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShipInfo.DAL
{
    public class AuxiliaryEngineConfiguration : IEntityTypeConfiguration<AuxiliaryEngine>
    {
        public void Configure(EntityTypeBuilder<AuxiliaryEngine> builder)
        {
            builder
                .HasKey(ae => ae.Id);

            builder
                .Property(ae => ae.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(me => me.Ships)
                .WithOne(ae => ae.AuxiliaryEngine)
                .HasForeignKey(s => s.AuxiliaryEngineId);

            builder
                .Property(ae => ae.AuxiliaryEngineType)
                .IsRequired()
                .HasMaxLength(30);

            builder
                 .Property(maep => maep.MaxAuxiliaryEnginePower)
                 .IsRequired();

            builder
                 .Property(maes => maes.MaxAuxiliaryEngineSpeed)
                 .IsRequired();

        }
    }
}