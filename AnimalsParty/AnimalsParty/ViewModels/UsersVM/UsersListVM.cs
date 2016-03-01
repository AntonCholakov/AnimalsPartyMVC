using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimalsParty.Models;

namespace AnimalsParty.ViewModels.UsersVM
{
    public class UsersListVM : ListVM
    {
        public List<User> Users { get; set; }
    }
}