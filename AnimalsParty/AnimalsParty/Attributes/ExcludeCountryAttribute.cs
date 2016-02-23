using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalsParty.Attributes
{
    public class ExcludeCountryAttribute : ValidationAttribute
    {
        private string country;

        public ExcludeCountryAttribute(string country)
        {
            this.country = country;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value.ToString().ToLower() == country.ToLower())
                {
                    return new ValidationResult("Country cannot be " + country);
                }
            }

            return ValidationResult.Success;
        }
    }
}