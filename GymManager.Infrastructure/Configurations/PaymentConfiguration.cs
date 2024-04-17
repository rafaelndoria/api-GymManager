using GymManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManager.Infrastructure.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DatePayment)
                .IsRequired();

            builder.Property(x => x.Value)
                .IsRequired()
                .HasPrecision(12, 2);

            builder.Property(x => x.TypePaymentId)
                .IsRequired();

            builder.HasOne(x => x.TypePayment)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.TypePaymentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
