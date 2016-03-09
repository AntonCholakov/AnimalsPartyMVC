using AnimalsParty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalsParty.Repositories
{
    public class TeamsRepository : BaseRepository<Team>
    {
        public TeamsRepository() : base() { }

        public TeamsRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}