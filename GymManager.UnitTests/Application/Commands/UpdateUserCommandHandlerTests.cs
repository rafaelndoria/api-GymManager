using GymManager.Application.Commands.UpdateUser;
using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using Moq;

namespace GymManager.UnitTests.Application.Commands
{
    public class UpdateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataOk_Executed_ReturnTrueUpdatedUser()
        {
            // Arrange
            var user = new User("Test", "Test", "Test");
            var hash = "Hash";

            var updateUserCommand = new UpdateUserCommand()
            {
                Id = 1,
                UserName = "Test",
                Password = "Test",
                Role = "Admin"
            };

            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            userRepositoryMock.Setup(x => x.GetByIdAsync(updateUserCommand.Id).Result).Returns(user);
            authServiceMock.Setup(x => x.ComputeSha256Hash(updateUserCommand.Password)).Returns(hash);

            var updateUserHandler = new UpdateUserHandler(userRepositoryMock.Object, authServiceMock.Object);

            // Act
            var updated = await updateUserHandler.Handle(updateUserCommand, new CancellationToken());   

            // Assert
            Assert.True(updated);

            userRepositoryMock.Verify(x => x.GetByIdAsync(updateUserCommand.Id).Result, Times.Once);
            authServiceMock.Verify(x => x.ComputeSha256Hash(updateUserCommand.Password), Times.Once);
        }

        [Fact]
        public async Task InputDataWithNotExistsId_Executed_ReturnFalseNotUpdatedUser()
        {
            // Arrange
            User user = null;

            var updateUserCommand = new UpdateUserCommand()
            {
                Id = 1,
                UserName = "Test",
                Password = "Test",
                Role = "Admin"
            };

            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            userRepositoryMock.Setup(x => x.GetByIdAsync(updateUserCommand.Id).Result).Returns(user);

            var updateUserHandler = new UpdateUserHandler(userRepositoryMock.Object, authServiceMock.Object);

            // Act
            var updated = await updateUserHandler.Handle(updateUserCommand, new CancellationToken());

            // Assert
            Assert.False(updated);

            userRepositoryMock.Verify(x => x.GetByIdAsync(updateUserCommand.Id).Result, Times.Once);
        }
    }
}
