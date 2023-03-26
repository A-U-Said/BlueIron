using App.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Repository.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User>? User { get; set; }
    }
}
