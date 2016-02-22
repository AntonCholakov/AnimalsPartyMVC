using AnimalsParty.Models;
using AnimalsParty.Repositories;
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
        CountriesRepository countriesRepo = new CountriesRepository();

        public ActionResult List()
        {
            CountriesListVM model = new CountriesListVM();

            model.Countries = countriesRepo.GetAll();

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
                country = countriesRepo.GetByID(id.Value);
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
                country = countriesRepo.GetByID(model.ID);
                if (country == null)
                {
                    return RedirectToAction("List");
                }
            }

            country.ID = model.ID;
            country.Name = model.Name;
            country.Population = model.Population;
            country.FoundationDate = model.FoundationDate;

            countriesRepo.Save(country);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("List");
            }

            countriesRepo.Delete(id.Value);

            return RedirectToAction("List");
        }
    }
}