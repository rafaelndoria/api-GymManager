using GymManager.Application.Commands.ActivateUser;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using Moq;

namespace GymManager.UnitTests.Application.Commands
{
    public class ActivateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputIdValid_Executed_ReturnTrue()
        {
            // Arrange
            var user = new User("Test", "Test", "Test");
            var activateUserCommand = new ActivateUserCommand(1);

            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock.Setup(x => x.GetByIdAsync(activateUserCommand.Id).Result).Returns(user);
            var activateUserHandler = new ActivateUserHandler(userRepositoryMock.Object);

            // Act
            var activated = await activateUserHandler.Handle(activateUserCommand, new CancellationToken());

            // Asset
            Assert.True(activated);

            userRepositoryMock.Verify(x => x.GetByIdAsync(activateUserCommand.Id), Times.Once);
            userRepositoryMock.Verify(x => x.UpdateAsync(user), Times.Once);
        }

        [Fact]
        public async Task InputIdInvalid_Executed_ReturnFalse()
        {
            // Arrange
            User user = null;
            var activateUserCommand = new ActivateUserCommand(1);

            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock.Setup(x => x.GetByIdAsync(activateUserCommand.Id).Result).Returns(user);

            var activateUserHandler = new ActivateUserHandler(userRepositoryMock.Object);

            // Act
            var updated = await activateUserHandler.Handle(activateUserCommand, new CancellationToken());

            // Assert
            Assert.False(updated);

            userRepositoryMock.Verify(x => x.GetByIdAsync(activateUserCommand.Id), Times.Once);
            userRepositoryMock.Verify(x => x.UpdateAsync(user), Times.Never);
        }
    }
}
