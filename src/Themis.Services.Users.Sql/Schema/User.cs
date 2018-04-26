using System.ComponentModel.DataAnnotations;

namespace Themis.Services.Users.Sql.Schema
{
    public class User
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Key]
        public string EmailAddress { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }
    }
}