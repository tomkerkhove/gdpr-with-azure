using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Themis.Services.Users.Sql.Schema;

namespace Themis.Services.Users.Sql.Repositories
{
    public class UserRepository
    {
        public async Task<User> GetAsync(string emailAddress)
        {
            using (var databaseContext = new UserDbContext())
            {
                var potentialUser = await databaseContext.Users.SingleOrDefaultAsync(user => user.EmailAddress.ToLower() == emailAddress.ToLower());
                return potentialUser;
            }
        }
    }
}