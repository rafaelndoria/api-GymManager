using GymManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManager.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.Active);

            builder.Property(x => x.DateCreated);

            builder.Property(x => x.PlanId)
                .IsRequired();

            builder.HasOne(x => x.Plan)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasIndex(x => x.Cpf)
                .IsUnique();
        }
    }
}
