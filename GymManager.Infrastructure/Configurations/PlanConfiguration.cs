using GymManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManager.Infrastructure.Configurations
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasPrecision(12, 2);

            builder.Property(x => x.EntriesPerDay)
                .IsRequired();

            builder.Property(x => x.Active)
                .IsRequired();

            builder.Property(x => x.DateCreated)
                .IsRequired();

            builder.Property(x => x.PlanTypeId)
                .IsRequired();

            builder.HasOne(x => x.PlanType)
                .WithMany(x => x.Plans)
                .HasForeignKey(x => x.PlanTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
