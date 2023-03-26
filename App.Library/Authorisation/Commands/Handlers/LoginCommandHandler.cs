using App.Repository.Interfaces;
using App.Repository.Models;
using App.Shared.Extensions;
using MediatR;
using System.Linq;

namespace App.Library.Authorisation.Commands.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public LoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            bool authenticated = false;

            var foundUser = await _userRepository.GetByCondition(x => x.Username == command.Username).ThrowIfNull("User not found");

            if (foundUser.FirstOrDefault().Password == command.Password)
            {
                authenticated = true;
            }

            command.Response = new Dto.Views.LoginView { Authenticated = authenticated };

            return Unit.Value;
        }
    }
}
