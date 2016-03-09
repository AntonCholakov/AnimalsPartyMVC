using AnimalsParty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalsParty.Repositories
{
    public class UsersRepository : BaseRepository<User>
    {
        public UsersRepository() : base() { }

        public UsersRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}