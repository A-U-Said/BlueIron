using App.Library.UserManagment.Dto.Views;
using App.Repository.Interfaces;
using App.Shared.Extensions;
using MediatR;

namespace App.Library.UserManagment.Queries.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserView>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserView> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var UserResult = (await _userRepository.GetByCondition(x => x.UserId == query.Id))
                .SingleOrDefault().ThrowIfNull($"User with ID ${query.Id} not found");

            return new UserView { UserId = UserResult.UserId, Name = $"{UserResult.FirstName} {UserResult.LastName}" };
        }
    }
}
