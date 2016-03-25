using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalsParty.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RememberMeHash { get; set; }

        public UserRoleEnum UserRole { get; set; }

        public int CityID { get; set; }

        public virtual City City { get; set; }

        public virtual List<Team> Teams { get; set; }
    }

    public enum UserRoleEnum { Admin, User }
}