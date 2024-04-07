using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.DeletePlanTime
{
    public class DeletePlanTimeHandler : IRequestHandler<DeletePlanTimeCommand, bool>
    {
        private readonly IPlanRepository _planRepository;

        public DeletePlanTimeHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }
            
        public async Task<bool> Handle(DeletePlanTimeCommand request, CancellationToken cancellationToken)
        {
            var planTime = await _planRepository.GetPlanTimeByIdAsync(request.Id);
            if (planTime == null)
                return false;
            await _planRepository.DeletePlanTimeAsync(planTime);
            return true;
        }
    }
}
