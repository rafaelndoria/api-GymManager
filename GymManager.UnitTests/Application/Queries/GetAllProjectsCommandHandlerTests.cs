using GymManager.Application.Queries.GetAllUsers;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using Moq;

namespace GymManager.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeUsersExist_Executed_ReturnThreeUserViewModels()
        {
            // Arrange
            var users = new List<User>
            { 
                new User("Usuario Teste 1", "Senha Teste 1", "Admin"),
                new User("Usuario Teste 2", "Senha Teste 2", "Admin"),
                new User("Usuario Teste 3", "Senha Teste 3", "Admin")
            };

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetAllAsync().Result).Returns(users);

            var getAllUsersQuery = new GetAllUsersQuery("");
            var getAllUsersHandler = new GetAllUsersHandler(userRepository.Object);

            // Act
            var userViewModelList = await getAllUsersHandler.Handle(getAllUsersQuery, new CancellationToken());

            // Assert
            Assert.NotNull(userViewModelList);
            Assert.NotEmpty(userViewModelList);

            userRepository.Verify(x => x.GetAllAsync().Result, Times.Once);
        }
    }
}
