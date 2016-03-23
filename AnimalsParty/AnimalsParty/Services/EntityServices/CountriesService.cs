using AnimalsParty.Models;
using AnimalsParty.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalsParty.Services.EntityServices
{
    public class CountriesService : BaseService<Country>
    {
        public CountriesService() : base() { }

        public CountriesService(UnitOfWork unitOfWork) : base() { }
    }
}