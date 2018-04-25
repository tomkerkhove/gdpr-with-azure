using System;
using System.Collections.Generic;
using System.Text;

namespace Themis.Services.Users.Sql.Schema
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
