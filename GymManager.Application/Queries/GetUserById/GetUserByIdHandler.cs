using GymManager.Application.ViewModels;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                return null;
            var userViewModel = new UserViewModel(user.Id ,user.UserName, user.Role, user.Active);
            return userViewModel;
        }
    }
}
