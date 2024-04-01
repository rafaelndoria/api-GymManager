using GymManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManager.Infrastructure.Configurations
{
    public class TypePaymentConfiguration : IEntityTypeConfiguration<TypePayment>
    {
        public void Configure(EntityTypeBuilder<TypePayment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new TypePayment(1, "CreditCard"),
                new TypePayment(2, "DebitCard"),
                new TypePayment(3, "PIX"),
                new TypePayment(4, "Money"));
        }
    }
}
