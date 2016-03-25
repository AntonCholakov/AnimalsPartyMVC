using AnimalsParty.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalsParty.Services
{
    public static class CookieService
    {
        public static void AuthenticateUser()
        {
            HttpCookie cookie = HttpContext.Current.Response.Cookies["rememberMe"];
            AuthenticationService.LoggedUser = new UsersRepository().GetAll().FirstOrDefault(u => u.RememberMeHash == cookie.Value);
        }
    }
}