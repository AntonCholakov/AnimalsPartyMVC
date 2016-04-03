using AnimalsParty.Models;
using AnimalsParty.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                rememberMeCookie.Value = Guid.NewGuid().ToString();
                rememberMeCookie.Expires.AddDays(10);
                HttpContext.Current.Response.Cookies.Set(rememberMeCookie);

                //Task.Run(() => EmailService.SendEmail(LoggedUser));
                //Task.Run(() => EmailService.SendEmails());
            }
        }

        public static void Logout()
        {
            //AuthenticateUser(null, null);

            LoggedUser = null;

            HttpContext.Current.Session["LoggedUser"] = null;

            HttpCookie cookie = HttpContext.Current.Request.Cookies["rememberMe"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
    }
}