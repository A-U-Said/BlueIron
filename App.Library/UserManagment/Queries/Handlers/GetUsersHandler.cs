using MediatR;
using App.Repository.Interfaces;
using App.Library.UserManagment.Dto.Views;

namespace App.Library.UserManagment.Queries.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserView>>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserView>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            return (await _userRepository.GetAll())
                .Select(x => new UserView() { 
                    UserId = x.UserId, 
                    Name = $"{x.FirstName} {x.LastName}" 
                });
        }
    }
}
