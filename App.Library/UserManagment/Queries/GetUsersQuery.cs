using App.Library.UserManagment.Dto.Views;
using MediatR;

namespace App.Library.UserManagment.Queries
{
    public record GetUsersQuery() : IRequest<IEnumerable<UserView>>;
}
