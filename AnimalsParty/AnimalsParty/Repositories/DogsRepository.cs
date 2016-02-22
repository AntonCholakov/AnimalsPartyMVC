using AnimalsParty.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnimalsParty.Repositories
{
    public class DogsRepository : BaseRepository<Dog>
    {
        public DogsRepository() : base() { }
    }
}