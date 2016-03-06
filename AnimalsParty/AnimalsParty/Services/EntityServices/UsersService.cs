using AnimalsParty.Models;
using AnimalsParty.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalsParty.Services.EntityServices
{
    public class UsersService : BaseService<User>
    {
        public UsersService() : base() { }

        public IEnumerable<SelectListItem> GetSelectedCities()
        {
            return new CitiesRepository().GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetSelectedTeams(List<Team> teams)
        {
            if (teams == null)
                teams = new List<Team>();

            var selectedIds = teams.Select(t => t.ID);

            return new TeamsRepository().GetAll().Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.ID.ToString(),
                Selected = selectedIds.Contains(t.ID)
            });
        }
    }
}