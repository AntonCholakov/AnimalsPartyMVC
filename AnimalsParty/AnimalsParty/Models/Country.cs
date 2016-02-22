using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalsParty.Models
{
    public class Country : BaseModel
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public DateTime FoundationDate { get; set; }
    }
}