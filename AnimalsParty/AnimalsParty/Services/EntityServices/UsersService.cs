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

        public UsersService(UnitOfWork unitOfWork) : base() { }

        public IEnumerable<SelectListItem> GetSelectedCities()
        {
            return new CitiesRepository().GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetSelectedTeams(List<Team> teams, string[] selectedTeams = null)
        {
            if (teams == null)
                teams = new List<Team>();

            List<string> selectedIds = teams.Select(t => t.ID.ToString()).ToList();

            if (selectedTeams != null)
                selectedIds.AddRange(selectedTeams);

            return new TeamsRepository().GetAll().Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.ID.ToString(),
                Selected = selectedIds.Contains(t.ID.ToString())
            });
        }

        public void UpdateUserTeams(User user, string[] selectedIds)
        {
            if (selectedIds == null)
                selectedIds = new string[0];

            if (user.Teams == null)
                user.Teams = new List<Team>();

            user.Teams.Clear();

            foreach (Team team in new TeamsRepository(base.unitOfWork).GetAll())
            {
                if (selectedIds.Contains(team.ID.ToString()))
                {
                    user.Teams.Add(team);
                }
            }

            //foreach (Team team in new TeamsRepository().GetAll().Where(t => selectedIds.Contains(t.ID.ToString())))
            //{
            //    user.Teams.Add(team);
            //}
        }
    }
}