namespace GymManager.Application.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel(int id, string name, string phoneNumber, string email, string cpf, bool active, DateTime dateCreated)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Cpf = cpf;
            Active = active;
            DateCreated = dateCreated;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public bool Active { get; private set; }
        public DateTime DateCreated { get; private set; }
    }
}
