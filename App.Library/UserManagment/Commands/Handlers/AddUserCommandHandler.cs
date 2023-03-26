using App.Repository.Interfaces;
using App.Repository.Models;
using MediatR;

namespace App.Library.UserManagment.Commands.Handlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetByCondition(x => x.Username == command.User.Username) != null)
            {
                throw new InvalidOperationException("User already exists");
            }

            await _userRepository.Create(new User { 
                UserId = command.User.UserId,
                Username = command.User.Username,
                FirstName = command.User.FirstName, 
                LastName = command.User.LastName,
                Password = command.User.Password,
            });
            await _userRepository.SaveChanges();

            command.Response = (await _userRepository.GetByCondition(x => x.UserId == command.User.UserId) != null)
                ? "User Created"
                : "User Could not be created";

            return Unit.Value;
        }
    }
}
