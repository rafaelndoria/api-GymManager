using GymManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManager.Infrastructure.Configurations
{
    public class WeekConfiguration : IEntityTypeConfiguration<Week>
    {
        public void Configure(EntityTypeBuilder<Week> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasData(
                new Week(1, "Sunday"),
                new Week(2, "Monday"),
                new Week(3, "Tuesday"),
                new Week(4, "Wednesday"),
                new Week(5, "Thusday"),
                new Week(6, "Friday"),
                new Week(7, "Saturday"));
        }
    }
}
