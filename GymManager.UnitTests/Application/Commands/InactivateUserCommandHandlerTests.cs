using GymManager.Application.Commands.InactivateUser;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using Moq;

namespace GymManager.UnitTests.Application.Commands
{
    public class InactivateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputIdOk_Executed_ReturnTrue()
        {
            // Arrange
            var user = new User("Test", "Test", "Test");

            var inactivateUserCommand = new InactivateUserCommand(1);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetByIdAsync(inactivateUserCommand.Id).Result).Returns(user);

            var inactivateUserHandler = new InactivateUserHandler(userRepositoryMock.Object);

            // Act
            var updated = await inactivateUserHandler.Handle(inactivateUserCommand, new CancellationToken());

            // Assert
            Assert.True(updated);

            userRepositoryMock.Verify(x => x.GetByIdAsync(inactivateUserCommand.Id), Times.Once);
            userRepositoryMock.Verify(x => x.UpdateAsync(user), Times.Once);
        }

        [Fact]
        public async Task InputIdInvalid_Executed_ReturnFalse()
        {
            // Arrange
            User user = null;

            var inactivateUserCommand = new InactivateUserCommand(1);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetByIdAsync(inactivateUserCommand.Id).Result).Returns(user);

            var inactivateUserHandler = new InactivateUserHandler(userRepositoryMock.Object);

            // Act
            var updated = await inactivateUserHandler.Handle(inactivateUserCommand, new CancellationToken());

            // Assert
            Assert.False(updated);

            userRepositoryMock.Verify(x => x.GetByIdAsync(inactivateUserCommand.Id), Times.Once);
            userRepositoryMock.Verify(x => x.UpdateAsync(user), Times.Never);
        }
    }
}
