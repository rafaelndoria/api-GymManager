using GymManager.Application.Services.Implementations;
using GymManager.Core.Entities;

namespace GymManager.UnitTests.Application.Services
{
    public class PlanServiceTests
    {
        [Fact]
        public void GivenTimeWithExistingInterval_Executed_ReturnFalse()
        {
            // Arrange
            var startTime = "08:00";
            var endTime = "12:00";

            var planTimes = new List<PlanTime>()
            { 
                new PlanTime("10:00", "12:00", 1, 1),         
                new PlanTime("13:00", "15:00", 1, 1),         
                new PlanTime("16:00", "18:00", 1, 1)         
            };

            var planService = new PlanService();

            // Act
            var isValid = planService.ValidPlanTime(planTimes, startTime, endTime);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void GivenTimeNotExistingInterval_Executed_ReturnTrue()
        {
            // Arrange
            var startTime = "08:00";
            var endTime = "12:00";

            var planTimes = new List<PlanTime>()
            {
                new PlanTime("05:00", "07:00", 1, 1),
                new PlanTime("13:00", "15:00", 1, 1),
                new PlanTime("16:00", "18:00", 1, 1),
                new PlanTime("18:00", "22:00", 1, 1)
            };

            var planService = new PlanService();

            // Act
            var isValid = planService.ValidPlanTime(planTimes, startTime, endTime);

            // Assert
            Assert.True(isValid);
        }
    }
}
