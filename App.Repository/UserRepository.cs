using App.Repository.Context;
using App.Repository.Interfaces;
using App.Repository.Models;

namespace App.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
