using GymManager.Application.Commands.AddPlanTime;
using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using Moq;

namespace GymManager.UnitTests.Application.Commands
{
    public class AddPlanTimeCommandHandlerTests
    {
        [Fact]
        public async Task InputDataOk_Executed_ReturnTrue()
        {
            // Arrange
            var planRepositoryMock = new Mock<IPlanRepository>();
            var planServiceMock = new Mock<IPlanService>();

            var addPlanTimeCommand = new AddPlanTimeCommand()
            { 
                StartTime = "08:00",
                EndTime = "12:00",
                DayWeekId = 1,
                PlanId = 1
            };

            var planTimes = new List<PlanTime>()
            {
                new PlanTime("13:00", "14:00", 1, 1)
            };

            planRepositoryMock.Setup(x => x.GetAllPlanTimeByIdPlanAsync(addPlanTimeCommand.PlanId, addPlanTimeCommand.DayWeekId).Result).Returns(planTimes);
            planServiceMock.Setup(x => x.ValidPlanTime(planTimes, addPlanTimeCommand.StartTime, addPlanTimeCommand.EndTime)).Returns(true);

            var addPlanTimeHandler = new AddPlanTimeHandler(planRepositoryMock.Object, planServiceMock.Object);

            // Act
            var created = await addPlanTimeHandler.Handle(addPlanTimeCommand, new CancellationToken());

            // Assert
            Assert.True(created);

            planRepositoryMock.Verify(x => x.GetAllPlanTimeByIdPlanAsync(addPlanTimeCommand.PlanId, addPlanTimeCommand.DayWeekId), Times.Once);
            planServiceMock.Verify(x => x.ValidPlanTime(planTimes, addPlanTimeCommand.StartTime, addPlanTimeCommand.EndTime), Times.Once);
        }
    }
}
