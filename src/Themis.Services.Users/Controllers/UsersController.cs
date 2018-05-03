using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Themis.Services.Users.Contracts;
using Themis.Services.Users.Repositories;

namespace Themis.Services.Users.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        ///     Gets the profile for a user
        /// </summary>
        /// <param name="emailAddress">Email address of the user</param>
        [HttpGet]
        [Route("{emailAddress}/profile")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description =
            "No profile was used with the specified email address")]
        [SwaggerResponse((int)HttpStatusCode.OK,
            Description = "Profile information linked to the specified email address", Type = typeof(UserProfile))]
        public async Task<IActionResult> Get(string emailAddress)
        {
            var userProfile = await _userRepository.GetProfileAsync(emailAddress);
            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }
    }
}