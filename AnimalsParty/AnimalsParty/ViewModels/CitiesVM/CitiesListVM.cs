using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimalsParty.Models;

namespace AnimalsParty.ViewModels.CitiesVM
{
    public class CitiesListVM : ListVM
    {
        public List<City> Cities { get; set; }
    }
}