using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Themis.Services.Users.Contracts;
using Themis.Services.Users.Repositories;

namespace Themis.Services.Users.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly UserRepository _userRepository = new UserRepository();

        /// <summary>
        ///     Gets the profile for a user
        /// </summary>
        /// <param name="emailAddress">Email address of the user</param>
        [HttpGet]
        [Route("api/users/{emailAddress}/profile")]
        [SwaggerResponse((int) HttpStatusCode.NotFound, Description =
            "No profile was used with the specified email address")]
        [SwaggerResponse((int) HttpStatusCode.OK,
            Description = "Profile information linked to the specified email address", Type = typeof(UserProfile))]
        public ActionResult Get(string emailAddress)
        {
            var userProfile = _userRepository.GetProfile(emailAddress);
            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }
    }
}