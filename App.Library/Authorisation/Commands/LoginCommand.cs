using App.Library.Authorisation.Dto.Views;
using App.Library.Core.Commands;

namespace App.Library.Authorisation.Commands
{
    public class LoginCommand : CommandBase<LoginView>
    {
        public LoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; }
        public string Password { get; }
    }
}
