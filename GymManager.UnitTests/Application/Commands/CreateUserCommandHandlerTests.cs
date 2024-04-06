using GymManager.Application.Commands.CreateUser;
using GymManager.Application.Services.Implementations;
using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using Moq;

namespace GymManager.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataOk_Executed_ReturnTokenJWT()
        {
            // Arrange
            var passwordHash = "dasndalkdnalkdnakld";
            var password = "Test";
            var userName = "Teste";
            var role = "Admin";
            var token = "dadadasdsadasasdasdasdasdas";

            var authServiceMock = new Mock<IAuthService>();
            var userRepositoryMock = new Mock<IUserRepository>();

            var createUserCommand = new CreateUserCommand
            {
                UserName = userName,
                Role = role,
                Password = password
            };

            var user = new User(userName, password, role);

            authServiceMock.Setup(x => x.ComputeSha256Hash(password)).Returns(passwordHash);
            authServiceMock.Setup(x => x.GenerateJwtToken(user.UserName, user.Password)).Returns(token);

            var createUserHandler = new CreateUserHandler(authServiceMock.Object, userRepositoryMock.Object);

            // Act
            var tokenReturn = await createUserHandler.Handle(createUserCommand, new CancellationToken());

            // Assert
            Assert.NotEmpty(tokenReturn);
            Assert.NotNull(tokenReturn);
            Assert.Equal(tokenReturn, token);

            authServiceMock.Verify(x => x.ComputeSha256Hash(password), Times.Once);
            authServiceMock.Verify(x => x.GenerateJwtToken(user.UserName, user.Password), Times.Once);

            userRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
