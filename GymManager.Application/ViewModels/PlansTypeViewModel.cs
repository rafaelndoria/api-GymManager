namespace GymManager.Application.ViewModels
{
    public class PlansTypeViewModel
    {
        public PlansTypeViewModel(int id, string name, int periodInMonths)
        {
            Id = id;
            Name = name;
            PeriodInMonths = periodInMonths;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int PeriodInMonths { get; private set; }
    }
}
