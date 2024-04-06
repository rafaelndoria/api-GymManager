using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            var user = new User(request.UserName, passwordHash, request.Role);
            await _userRepository.CreateAsync(user);
            var token = _authService.GenerateJwtToken(user.UserName, user.Role);
            return token;
        }
    }
}
