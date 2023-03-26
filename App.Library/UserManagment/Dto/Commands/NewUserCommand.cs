
namespace App.Library.UserManagment.Dto.Commands
{
    public class NewUserCommand
    {
        public Guid UserId { get; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
