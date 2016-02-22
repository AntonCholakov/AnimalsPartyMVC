using AnimalsParty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalsParty.Repositories
{
    public class CatsRepository : BaseRepository<Cat>
    {
        public CatsRepository() : base() { }
    }
}