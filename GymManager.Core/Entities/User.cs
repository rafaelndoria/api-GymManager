namespace GymManager.Core.Entities
{
    public class User : Entity
    {
        public User(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
    }
}
