using AnimalsParty.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalsParty.ViewModels.CountriesVM
{
    public class CountriesEditVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please input a name! It is required!")]
        [StringLength(80, MinimumLength=3, ErrorMessage="Minimum length is 3 and maximum length is 80")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Name can consist of letters, spaces and dashes only!")]
        [ExcludeCountry("Bulgaria")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input a population! It is required!")]
        [Range(10, int.MaxValue)]
        public int Population { get; set; }

        [Required(ErrorMessage = "Please input a foundation date! It is required!")]
        [DataType(DataType.Date)]
        [Display(Name="Foundation Date")]
        public DateTime FoundationDate { get; set; }
    }
}