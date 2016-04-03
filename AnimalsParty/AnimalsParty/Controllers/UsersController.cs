using AnimalsParty.Models;
using AnimalsParty.Repositories;
using AnimalsParty.Services.EntityServices;
using AnimalsParty.ViewModels.UsersVM;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalsParty.Controllers
{
    public class UsersController : BaseController
    {
        public ActionResult List()
        {
            UsersService usersService = new UsersService();

            UsersListVM model = new UsersListVM();
            TryUpdateModel(model);

            model.Users = usersService.GetAll();

            if (!String.IsNullOrEmpty(model.Search))
            {
                model.Users = model.Users.Where(u => u.FirstName.ToLower().Contains(model.Search.ToLower()) ||
                                                    u.LastName.ToLower().Contains(model.Search.ToLower())).ToList();
            }

            switch (model.SortOrder)
            {
                case "city_asc":
                    model.Users = model.Users.OrderBy(u => u.City.Name).ToList();
                    break;
                case "city_desc":
                    model.Users = model.Users.OrderByDescending(u => u.City.Name).ToList();
                    break;
                case "username_asc":
                    model.Users = model.Users.OrderBy(u => u.Username).ToList();
                    break;
                case "username_desc":
                    model.Users = model.Users.OrderByDescending(u => u.Username).ToList();
                    break;
                case "lname_asc":
                    model.Users = model.Users.OrderBy(u => u.LastName).ToList();
                    break;
                case "lname_desc":
                    model.Users = model.Users.OrderByDescending(u => u.LastName).ToList();
                    break;
                case "fname_desc":
                    model.Users = model.Users.OrderByDescending(u => u.FirstName).ToList();
                    break;
                case "fname_asc":
                default:
                    model.Users = model.Users.OrderBy(u => u.FirstName).ToList();
                    break;
            }

            int pageSize = 2;
            int pageNumber = model.Page ?? 1;
            model.PagedUsers = model.Users.ToPagedList(pageNumber, pageSize);

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            UsersService usersService = new UsersService();

            UsersEditVM model = new UsersEditVM();
            User user;

            if (!id.HasValue)
            {
                user = new User();
            }
            else
            {
                user = usersService.GetByID(id.Value);
                if (user == null)
                {
                    return RedirectToAction("List");
                }
            }

            model.ID = user.ID;
            model.Username = user.Username;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.UserRole = user.UserRole;
            model.CityID = user.CityID;

            //model.Countries = new CountriesRepository().GetAll(); 1
            //model.Countries = new SelectList(new CountriesRepository().GetAll(), "ID", "Name"); //2 
            model.Cities = usersService.GetSelectedCities(); // 3
            model.Teams = usersService.GetSelectedTeams(user.Teams);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            UsersService usersService = new UsersService(unitOfWork);

            UsersEditVM model = new UsersEditVM();
            TryUpdateModel(model);

            User user;
            if (model.ID == 0)
            {
                user = new User();
            }
            else
            {
                user = usersService.GetByID(model.ID);
                if (user == null)
                {
                    return RedirectToAction("List");
                }
            }

            if (!ModelState.IsValid)
            {
                model.Cities = usersService.GetSelectedCities();
                model.Teams = usersService.GetSelectedTeams(user.Teams, model.SelectedTeams);

                return View(model);
            }

            user.ID = model.ID;
            user.Username = model.Username;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserRole = model.UserRole;
            user.CityID = model.CityID;

            usersService.UpdateUserTeams(user, model.SelectedTeams);

            usersService.Save(user);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            UsersService usersService = new UsersService(unitOfWork);

            if (!id.HasValue)
            {
                return RedirectToAction("List");
            }

            usersService.Delete(id.Value);

            return RedirectToAction("List");
        }
    }
}