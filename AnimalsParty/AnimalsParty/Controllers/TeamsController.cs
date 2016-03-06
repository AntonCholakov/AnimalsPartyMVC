using AnimalsParty.Models;
using AnimalsParty.Services.EntityServices;
using AnimalsParty.ViewModels.TeamsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalsParty.Controllers
{
    public class TeamsController : Controller
    {
        TeamsService teamsService = new TeamsService();
        public ActionResult List()
        {
            TeamsListVM model = new TeamsListVM();
            TryUpdateModel(model);

            model.Teams = teamsService.GetAll();

            if (!String.IsNullOrEmpty(model.Search))
            {
                model.Teams = model.Teams.Where(t => t.Name.ToLower().Contains(model.Search.ToLower())).ToList();
            }

            switch (model.SortOrder)
            {
                case "name_desc":
                    model.Teams = model.Teams.OrderByDescending(t => t.Name).ToList();
                    break;
                case "name_asc":
                default:
                    model.Teams = model.Teams.OrderBy(t => t.Name).ToList();
                    break;
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            TeamsEditVM model = new TeamsEditVM();
            Team team;

            if (!id.HasValue)
            {
                team = new Team();
            }
            else
            {
                team = teamsService.GetByID(id.Value);
                if (team == null)
                {
                    return RedirectToAction("List");
                }
            }

            model.ID = team.ID;
            model.Name = team.Name;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            TeamsEditVM model = new TeamsEditVM();
            TryUpdateModel(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Team team;
            if (model.ID == 0)
            {
                team = new Team();
            }
            else
            {
                team = teamsService.GetByID(model.ID);
                if (team == null)
                {
                    return RedirectToAction("List");
                }
            }

            team.ID = model.ID;
            team.Name = model.Name;

            teamsService.Save(team);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("List");
            }

            teamsService.Delete(id.Value);

            return RedirectToAction("List");
        }
    }
}