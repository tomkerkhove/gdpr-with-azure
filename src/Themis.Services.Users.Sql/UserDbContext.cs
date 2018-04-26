using Microsoft.EntityFrameworkCore;
using Themis.Services.Users.Sql.Schema;

namespace Themis.Services.Users.Sql
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> dbOptions) : base(dbOptions)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}