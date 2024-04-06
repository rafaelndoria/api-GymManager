using GymManager.Application.Services.Interfaces;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UpdateUserHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                return false;
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            user.Update(request.UserName, passwordHash, request.Role);
            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}
