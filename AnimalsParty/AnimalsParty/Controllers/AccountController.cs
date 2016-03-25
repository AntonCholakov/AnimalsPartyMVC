using AnimalsParty.Services;
using AnimalsParty.ViewModels.AccountVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalsParty.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login(string RedirectUrl)
        {
            AccountLoginVM model = new AccountLoginVM();
            model.RedirectUrl = RedirectUrl;

            return View(model);
        }

        [HttpPost]
        public ActionResult Login()
        {
            AccountLoginVM model = new AccountLoginVM();
            TryUpdateModel(model);

            AuthenticationService.AuthenticateUser(model.Username, model.Password);

            if (AuthenticationService.LoggedUser != null)
            {
                if (!String.IsNullOrEmpty(model.RedirectUrl))
                    return Redirect(model.RedirectUrl);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationService.Logout();

            return RedirectToAction("Login");
        }
    }
}