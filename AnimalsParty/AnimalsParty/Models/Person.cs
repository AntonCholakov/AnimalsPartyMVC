using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalsParty.Models
{
    public class Person : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Dog> Dogs { get; set; }
        public virtual List<Cat> Cats { get; set; }
    }
}