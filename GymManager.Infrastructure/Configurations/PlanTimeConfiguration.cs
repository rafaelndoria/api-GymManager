using GymManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManager.Infrastructure.Configurations
{
    public class PlanTimeConfiguration : IEntityTypeConfiguration<PlanTime>
    {
        public void Configure(EntityTypeBuilder<PlanTime> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StartTime)
                .IsRequired();

            builder.Property(x => x.EndTime)
                .IsRequired();

            builder.Property(x => x.WeekId)
                .IsRequired();

            builder.Property(x => x.PlanId)
                .IsRequired();

            builder.HasOne(x => x.Week)
                .WithMany(x => x.PlanTimes)
                .HasForeignKey(x => x.WeekId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Plan)
                .WithMany(x => x.PlanTimes)
                .HasForeignKey(x => x.PlanId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
