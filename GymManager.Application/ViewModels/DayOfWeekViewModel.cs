namespace GymManager.Application.ViewModels
{
    public class DayOfWeekViewModel
    {
        public DayOfWeekViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
