using AnimalsParty.Models;
using AnimalsParty.Services.EntityServices;
using AnimalsParty.ViewModels.CountriesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalsParty.Controllers
{
    public class CountriesController : Controller
    {
        CountriesService countriesService = new CountriesService();

        public ActionResult List()
        {
            CountriesListVM model = new CountriesListVM();
            TryUpdateModel(model);

            model.Countries = countriesService.GetAll();

            if (!String.IsNullOrEmpty(model.Search))
            {
                model.Countries = model.Countries.Where(c => c.Name.ToLower().Contains(model.Search.ToLower())).ToList();
            }

            model.Props = new Dictionary<string, object>();

            switch (model.SortOrder)
            {
                case "population_asc":
                    model.Countries = model.Countries.OrderBy(c => c.Population).ToList();
                    break;
                case "population_desc":
                    model.Countries = model.Countries.OrderByDescending(c => c.Population).ToList();
                    break;
                case "date_asc":
                    model.Countries = model.Countries.OrderBy(c => c.FoundationDate).ToList();
                    break;
                case "date_desc":
                    model.Countries = model.Countries.OrderByDescending(c => c.FoundationDate).ToList();
                    break;
                case "name_desc":
                    model.Countries = model.Countries.OrderByDescending(c => c.Name).ToList();
                    break;
                case "name_asc":
                default:
                    model.Countries = model.Countries.OrderBy(c => c.Name).ToList();
                    break;
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            CountriesEditVM model = new CountriesEditVM();
            Country country;

            if (!id.HasValue)
            {
                country = new Country();
            }
            else
            {
                country = countriesService.GetByID(id.Value);
                if (country == null)
                {
                    return RedirectToAction("List");
                }
            }

            model.ID = country.ID;
            model.Name = country.Name;
            model.Population = country.Population;
            model.FoundationDate = country.FoundationDate;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            CountriesEditVM model = new CountriesEditVM();
            TryUpdateModel(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Country country;
            if (model.ID == 0)
            {
                country = new Country();
            }
            else
            {
                country = countriesService.GetByID(model.ID);
                if (country == null)
                {
                    return RedirectToAction("List");
                }
            }

            country.ID = model.ID;
            country.Name = model.Name;
            country.Population = model.Population;
            country.FoundationDate = model.FoundationDate;

            countriesService.Save(country);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("List");
            }

            countriesService.Delete(id.Value);

            return RedirectToAction("List");
        }
    }
}