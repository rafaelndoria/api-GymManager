using GymManager.Application.Queries.GetUserById;
using GymManager.Application.ViewModels;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using Moq;

namespace GymManager.UnitTests.Application.Queries
{
    public class GetUserByIdCommandHandlerTests
    {
        [Fact]
        public async Task InputIdOk_Executed_ReturnUserViewModel()
        {
            // Arrange 
            var getUserByIdQuery = new GetUserByIdQuery(1);

            var user = new User("Test", "Test", "Test");

            var userRepositortMock = new Mock<IUserRepository>();
            userRepositortMock.Setup(x => x.GetByIdAsync(getUserByIdQuery.Id).Result).Returns(user);

            var getUserByIdHandler = new GetUserByIdHandler(userRepositortMock.Object);

            // Act
            var userViewModelReturn = await getUserByIdHandler.Handle(getUserByIdQuery, new CancellationToken());

            // Assert
            Assert.NotNull(userViewModelReturn);

            userRepositortMock.Verify(x => x.GetByIdAsync(getUserByIdQuery.Id), Times.Once);
        }

        [Fact]
        public async Task InputIdInvalid_Executed_ReturnNull()
        {
            // Arrange 
            var getUserByIdQuery = new GetUserByIdQuery(1);

            User user = null;

            var userRepositortMock = new Mock<IUserRepository>();
            userRepositortMock.Setup(x => x.GetByIdAsync(getUserByIdQuery.Id).Result).Returns(user);

            var getUserByIdHandler = new GetUserByIdHandler(userRepositortMock.Object);

            // Act
            var userViewModelReturn = await getUserByIdHandler.Handle(getUserByIdQuery, new CancellationToken());

            // Assert
            Assert.Null(userViewModelReturn);

            userRepositortMock.Verify(x => x.GetByIdAsync(getUserByIdQuery.Id), Times.Once);
        }
    }
}
