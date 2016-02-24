using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimalsParty.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using AnimalsParty.Attributes;

namespace AnimalsParty.ViewModels.CitiesVM
{
    public class CitiesEditVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please input a name! It is required!")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 80")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage="Name can consist of letters, spaces and dashes only!")]
        public string Name { get; set; }

        [RegularExpression(@"^(\d{4})$", ErrorMessage="Post Code must be 4 digits")]
        [Display(Name = "Post Code")]
        public int PostCode { get; set; }

        [Display(Name="Country")]
        public int CountryID { get; set; }

        //public IEnumerable<Country> Countries { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}