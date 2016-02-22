using AnimalsParty.Models;
using AnimalsParty.Repositories;
using AnimalsParty.ViewModels.DogsVM;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AnimalsParty.Controllers
{
    public class DogsController : Controller
    {
        DogsRepository dogsRepo = new DogsRepository();

        public ActionResult List()
        {
            DogsListVM model = new DogsListVM();
            model.Dogs = dogsRepo.GetAll();

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            DogsEditVM model = new DogsEditVM();
            Dog dog;

            if (!id.HasValue)
            {
                dog = new Dog();
            }
            else
            {
                dog = dogsRepo.GetByID(id.Value);

                if (dog == null)
                {
                    return RedirectToAction("List");
                }
            }

            model.ID = dog.ID;
            model.Breed = dog.Breed;
            model.PersonID = dog.PersonID;
            model.Cats = dog.Cats;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit()
        {
            DogsEditVM model = new DogsEditVM();
            TryUpdateModel(model);

            Dog dog;
            if (model.ID == 0)
            {
                dog = new Dog();
            }
            else
            {
                dog = dogsRepo.GetByID(model.ID);

                if (dog == null)
                {
                    return RedirectToAction("List");
                }
            }

            dog.Name = model.Name;
            dog.PersonID = model.PersonID;
            dog.Breed = model.Breed;
            dog.Cats = model.Cats;

            dogsRepo.Save(dog);

            return RedirectToAction("List");
        }
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("List");
            }

            Dog dog = dogsRepo.GetByID(id.Value);

            if (dog != null)
                dogsRepo.Delete(id.Value);

            return RedirectToAction("List");
        }
    }
}