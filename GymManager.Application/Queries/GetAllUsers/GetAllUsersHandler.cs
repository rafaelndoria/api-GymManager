using GymManager.Application.ViewModels;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Queries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            var usersViewModel = users
                .Select(u => new UserViewModel(u.Id, u.UserName, u.Role, u.Active));
            return usersViewModel;
        }
    }
}
