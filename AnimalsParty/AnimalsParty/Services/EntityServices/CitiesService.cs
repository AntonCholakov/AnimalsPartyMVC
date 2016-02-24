using AnimalsParty.Models;
using AnimalsParty.Repositories;
using AnimalsParty.ViewModels.CitiesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalsParty.Services.EntityServices
{
    public class CitiesService : BaseService<City>
    {
        public CitiesService() : base() { }

        public IEnumerable<SelectListItem> GetSelectedCountries()
        {
            return new CountriesRepository().GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString()
            });
        }
    }
}