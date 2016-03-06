using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimalsParty.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AnimalsParty.ViewModels.UsersVM
{
    public class UsersEditVM
    {
        public int ID { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 80")]
        [RegularExpression(@"^([A-z.-_]+)$", ErrorMessage = "Username can consist of letters, dashes and underscores only!")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 80")]
        [RegularExpression(@"^([A-z-]+)$", ErrorMessage = "Name can consist of letters and dashes only!")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 80")]
        [RegularExpression(@"^([A-z-]+)$", ErrorMessage = "Name can consist of letters and dashes only!")]
        public string LastName { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 160")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User Role")]
        public UserRoleEnum UserRole { get; set; }

        [Required]
        [Display(Name="City")]
        public int CityID { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<SelectListItem> Teams { get; set; }
    }
}