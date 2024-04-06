namespace GymManager.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string userName, string role, bool active)
        {
            Id = id;
            UserName = userName;
            Role = role;
            Active = active;
        }

        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string Role { get; private set; }
        public bool Active { get; private set; }
    }
}
