using AnimalsParty.Models;
using AnimalsParty.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalsParty.Services.EntityServices
{
    public class TeamsService : BaseService<Team>
    {
        public TeamsService() : base() { }

        public TeamsService(UnitOfWork unitOfWork) : base() { }
    }
}