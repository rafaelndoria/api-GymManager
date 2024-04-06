using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.ActivateUser
{
    public class ActivateUserHandler : IRequestHandler<ActivateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public ActivateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                return false;
            user.Activate();
            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}
