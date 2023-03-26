using App.Library.Core.Commands;
using App.Library.UserManagment.Dto.Commands;
using App.Repository.Models;

namespace App.Library.UserManagment.Commands
{
    public class AddUserCommand : CommandBase<string>
    {
        public AddUserCommand(NewUserCommand user)
        { 
            User = user;
        }

        public NewUserCommand User { get; set; }
    }
}
