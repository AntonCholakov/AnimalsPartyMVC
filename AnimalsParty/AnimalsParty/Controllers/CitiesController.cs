using AnimalsParty.Models;
using AnimalsParty.Services.EntityServices;
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
        CitiesService citiesService = new CitiesService();

        public ActionResult List()
        {
            CitiesListVM model = new CitiesListVM();
            TryUpdateModel(model);

            model.Cities = citiesService.GetAll();

            if (!String.IsNullOrEmpty(model.Search))
            {
                model.Cities = model.Cities.Where(c => c.Name.ToLower().Contains(model.Search.ToLower())).ToList();
            }

            model.Props = new Dictionary<string, object>();

            switch (model.SortOrder)
            {
                case "country_asc":
                    model.Cities = model.Cities.OrderBy(c => c.Country.Name).ToList();
                    break;
                case "country_desc":
                    model.Cities = model.Cities.OrderByDescending(c => c.Country.Name).ToList();
                    break;
                case "name_desc":
                    model.Cities = model.Cities.OrderByDescending(c => c.Name).ToList();
                    break;
                case "name_asc":
                default:
                    model.Cities = model.Cities.OrderBy(c => c.Name).ToList();
                    break;
            }

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
                city = citiesService.GetByID(id.Value);
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
            model.Countries = citiesService.GetSelectedCountries(); // 3

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            CitiesEditVM model = new CitiesEditVM();
            TryUpdateModel(model);

            if (!ModelState.IsValid)
            {
                model.Countries = citiesService.GetSelectedCountries();
                return View(model);
            }

            City city;
            if (model.ID == 0)
            {
                city = new City();
            }
            else
            {
                city = citiesService.GetByID(model.ID);
                if (city == null)
                {
                    return RedirectToAction("List");
                }
            }

            city.ID = model.ID;
            city.Name = model.Name;
            city.PostCode = model.PostCode;
            city.CountryID = model.CountryID;

            citiesService.Save(city);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("List");
            }

            citiesService.Delete(id.Value);

            return RedirectToAction("List");
        }
    }
}