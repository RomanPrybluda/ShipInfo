using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipInfo.Domain.Entities;

namespace ShipInfo.DAL
{
    public class OperatorConfiguration : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder
                .HasKey(op => op.Id);

            builder
                .Property(op => op.Id)
                .HasDefaultValueSql("NEWID()");

            builder
                .HasMany(s => s.Ships)
                .WithOne(op => op.Operator)
                .HasForeignKey(op => op.OperatorId);

            builder
                .Property(op => op.OperatorName)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}