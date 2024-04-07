using GymManager.Application.ViewModels;
using MediatR;

namespace GymManager.Application.Queries.GetAllDayOfWeek
{
    public class GetAllDayOfWeekQuery : IRequest<IEnumerable<DayOfWeekViewModel>>
    {
    }
}
