using GymManager.Application.Commands.LoginUser;
using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using Moq;

namespace GymManager.UnitTests.Application.Commands
{
    public class LoginUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataOk_Executed_ReturnTokenJWT()
        {
            // Arrange
            var password = "Test";
            var hash = "Teste";
            var token = "Test Token";
            var userName = "Test";
            var role = "Admin";

            var user = new User(userName, hash, role);

            var authServiceMock = new Mock<IAuthService>();
            var userRepositoryMock = new Mock<IUserRepository>();

            authServiceMock.Setup(x => x.ComputeSha256Hash(password)).Returns(hash);
            authServiceMock.Setup(x => x.GenerateJwtToken(user.UserName, user.Role)).Returns(token);
            userRepositoryMock.Setup(x => x.GetByUserNameAndPasswordHashAsync(userName, hash).Result).Returns(user);

            var loginUserCommand = new LoginUserCommand()
            {
                UserName = userName,
                Password = password
            };

            var loginUserHandler = new LoginUserHandler(authServiceMock.Object, userRepositoryMock.Object);

            // Act
            var tokenReturn = await loginUserHandler.Handle(loginUserCommand, new CancellationToken());

            // Assert
            Assert.Equal(token, tokenReturn);
            Assert.NotNull(tokenReturn);

            authServiceMock.Verify(x => x.ComputeSha256Hash(password), Times.Once);
            authServiceMock.Verify(x => x.GenerateJwtToken(user.UserName, user.Role), Times.Once);
            userRepositoryMock.Verify(x => x.GetByUserNameAndPasswordHashAsync(userName, hash), Times.Once);
        }

        [Fact]
        public async Task InputDataInvalid_Execute_ReturnTokenJWTNull()
        {
            // Arrange
            var password = "Test";
            var hash = "Teste";
            var token = "Test Token";
            var userName = "Test";
            var role = "Admin";

            User user = null;

            var authServiceMock = new Mock<IAuthService>();
            var userRepositoryMock = new Mock<IUserRepository>();

            authServiceMock.Setup(x => x.ComputeSha256Hash(password)).Returns(hash);
            authServiceMock.Setup(x => x.GenerateJwtToken(userName, role)).Returns(token);

            userRepositoryMock.Setup(x => x.GetByUserNameAndPasswordHashAsync(userName, hash).Result).Returns(user);

            var loginUserCommand = new LoginUserCommand()
            {
                UserName = userName,
                Password = password
            };

            var loginUserHandler = new LoginUserHandler(authServiceMock.Object, userRepositoryMock.Object);

            // Act
            var tokenReturn = await loginUserHandler.Handle(loginUserCommand, new CancellationToken());

            // Assert
            Assert.NotEqual(token, tokenReturn);
            Assert.Null(tokenReturn);

            authServiceMock.Verify(x => x.ComputeSha256Hash(password), Times.Once);
            authServiceMock.Verify(x => x.GenerateJwtToken(userName, role), Times.Never);

            userRepositoryMock.Verify(x => x.GetByUserNameAndPasswordHashAsync(userName, hash), Times.Once);
        }
    }
}
