using AnimalsParty.Models;
using AnimalsParty.Repositories;
using AnimalsParty.ViewModels.CitiesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalsParty.Controllers
{
    public class CitiesController : Controller
    {
        CitiesRepository citiesRepo = new CitiesRepository();

        public ActionResult List()
        {
            CitiesListVM model = new CitiesListVM();

            model.Cities = citiesRepo.GetAll();

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            CitiesEditVM model = new CitiesEditVM();
            City city;

            if (!id.HasValue)
            {
                city = new City();
            }
            else
            {
                city = citiesRepo.GetByID(id.Value);
                if (city == null)
                {
                    return RedirectToAction("List");
                }
            }

            model.ID = city.ID;
            model.Name = city.Name;
            model.PostCode = city.PostCode;
            model.CountryID = city.CountryID;

            //model.Countries = new CountriesRepository().GetAll(); 1
            //model.Countries = new SelectList(new CountriesRepository().GetAll(), "ID", "Name"); //2 
            model.Countries = ToSelectListItem(model, city.CountryID); // 3

            return View(model);
        }

        public IEnumerable<SelectListItem> ToSelectListItem(CitiesEditVM model, int selectedID)
        {
            return new CountriesRepository().GetAll().Select(c => new SelectListItem
                {
                    Selected = (model.CountryID == selectedID),
                    Text = c.Name,
                    Value = c.ID.ToString()
                });
        }

        [HttpPost]
        public ActionResult Edit()
        {
            CitiesEditVM model = new CitiesEditVM();
            TryUpdateModel(model);

            if (!ModelState.IsValid)
            {
                model.Countries = ToSelectListItem(model, model.CountryID);
                return View(model);
            }

            City city;
            if (model.ID == 0)
            {
                city = new City();
            }
            else
            {
                city = citiesRepo.GetByID(model.ID);
                if (city == null)
                {
                    return RedirectToAction("List");
                }
            }

            city.ID = model.ID;
            city.Name = model.Name;
            city.PostCode = model.PostCode;
            city.CountryID = model.CountryID;

            citiesRepo.Save(city);

            return RedirectToAction("List");
        }
    }
}