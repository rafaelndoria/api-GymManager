namespace GymManager.Core.Entities
{
    public class User : Entity
    {
        public User(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role.ToLower();

            Active = true;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public bool Active { get; private set; }

        public void Update(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role.ToLower();
        }

        public void Activate()
        {
            Active = true;
        }

        public void Inactivate()
        {
            Active = false;
        }
    }
}
