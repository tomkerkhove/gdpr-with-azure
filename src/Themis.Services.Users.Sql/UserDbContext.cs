using Microsoft.EntityFrameworkCore;
using Themis.Services.Users.Sql.Schema;

namespace Themis.Services.Users.Sql
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}