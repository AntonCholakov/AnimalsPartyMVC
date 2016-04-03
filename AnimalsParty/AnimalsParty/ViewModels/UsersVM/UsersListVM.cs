using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimalsParty.Models;
using PagedList;

namespace AnimalsParty.ViewModels.UsersVM
{
    public class UsersListVM : ListVM
    {
        public List<User> Users { get; set; }

        public IPagedList<User> PagedUsers { get; set; }

        public int? Page { get; set; }
    }
}