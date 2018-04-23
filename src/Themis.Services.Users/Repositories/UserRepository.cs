using System.Collections.Generic;
using System.Linq;
using Themis.Services.Users.Contracts;

namespace Themis.Services.Users.Repositories
{
    public class UserRepository
    {
        private readonly List<UserProfile> _userProfiles = new List<UserProfile>
        {
            new UserProfile
            {
                FirstName = "Bill",
                LastName = "Bracket",
                EmailAddress = "Bill.Bracket@codito.com"
            },
            new UserProfile
            {
                FirstName = "Tom",
                LastName = "Kerkhove",
                EmailAddress = "Tom.Kerkhove@codit.eu"
            }
        };

        /// <summary>
        /// Gets the profile linked to a specific user
        /// </summary>
        /// <param name="emailAddress">Email address of the user</param>
        public UserProfile GetProfile(string emailAddress)
        {
            return _userProfiles.SingleOrDefault(user => user.EmailAddress == emailAddress);
        }
    }
}