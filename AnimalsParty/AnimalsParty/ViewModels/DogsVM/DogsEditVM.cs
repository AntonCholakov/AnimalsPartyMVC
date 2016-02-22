using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimalsParty.Models;

namespace AnimalsParty.ViewModels.DogsVM
{
    public class DogsEditVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PersonID { get; set; }
        public BreedEnum Breed { get; set; }

        public Person Person { get; set; }

        public List<Cat> Cats { get; set; }
    }
}