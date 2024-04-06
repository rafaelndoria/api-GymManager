namespace GymManager.Application.ViewModels
{
    public class TokenViewModel
    {
        public TokenViewModel(string token)
        {
            Token = token;
        }

        public string Token { get; private set; }
    }
}
