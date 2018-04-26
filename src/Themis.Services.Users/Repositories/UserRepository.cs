using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Themis.Services.Users.Contracts;
using Themis.Services.Users.Sql;

namespace Themis.Services.Users.Repositories
{
    public class UserRepository
    {
        private readonly UserDbContext dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the profile linked to a specific user
        /// </summary>
        /// <param name="emailAddress">Email address of the user</param>
        public async Task<UserProfile> GetProfileAsync(string emailAddress)
        {
            var potentialUser = await dbContext.Users.Where(user => user.EmailAddress.ToLower() == emailAddress.ToLower())
                                                    .Select(user => new UserProfile
                                                                    {
                                                                        EmailAddress = user.EmailAddress,
                                                                        FirstName = user.FirstName,
                                                                        LastName = user.LastName
                                                                    })
                                                    .SingleOrDefaultAsync();

            return potentialUser;
        }
    }
}