using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalsParty.ViewModels.TeamsVM
{
    public class TeamsEditVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please input a name! It is required!")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 80")]
        [RegularExpression(@"^([A-z -']+)$", ErrorMessage = "Name can consist of letters, spaces, dashes and apostrophe only!")]
        public string Name { get; set; }
    }
}