﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimalsParty.Models;

namespace AnimalsParty.ViewModels.CountriesVM
{
    public class CountriesListVM : ListVM
    {
        public List<Country> Countries { get; set; }
    }
}