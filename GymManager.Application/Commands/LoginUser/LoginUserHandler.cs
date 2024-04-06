using GymManager.Application.Services.Interfaces;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            var user = await _userRepository.GetByUserNameAndPasswordHashAsync(request.UserName, passwordHash);
            if (user == null)
                return null;
            var token = _authService.GenerateJwtToken(user.UserName, user.Role);
            return token;
        }
    }
}
