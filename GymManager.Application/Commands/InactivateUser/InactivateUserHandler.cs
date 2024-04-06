using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.InactivateUser
{
    public class InactivateUserHandler : IRequestHandler<InactivateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public InactivateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(InactivateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                return false;
            user.Inactivate();
            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}
