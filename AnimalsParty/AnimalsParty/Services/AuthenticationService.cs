using AnimalsParty.Models;
using AnimalsParty.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalsParty.Services
{
    public static class AuthenticationService
    {
        public static User LoggedUser { get; set; }

        public static void AuthenticateUser(string username, string password)
        {
            UsersRepository usersRepo = new UsersRepository();
            LoggedUser = usersRepo.GetAll().FirstOrDefault(u => u.Username == username && u.Password == password);

            if (LoggedUser != null)
            {
                HttpContext.Current.Session["LoggedUser"] = LoggedUser;

                HttpCookie rememberMeCookie = new HttpCookie("rememberMe");
                LoggedUser.RememberMeHash = Guid.NewGuid().ToString();

                usersRepo.Save(LoggedUser);

                rememberMeCookie.Value = LoggedUser.RememberMeHash;
                rememberMeCookie.Expires.AddDays(10);
                HttpContext.Current.Response.Cookies.Add(rememberMeCookie);
            }
        }

        public static void Logout()
        {
            //AuthenticateUser(null, null);
            LoggedUser.RememberMeHash = null;
            new UsersRepository().Save(LoggedUser);

            LoggedUser = null;

            HttpContext.Current.Session["LoggedUser"] = null;

            HttpCookie cookie = HttpContext.Current.Response.Cookies["rememberMe"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
    }
}