using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnimalsParty.Services;

namespace AnimalsParty.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Response.Cookies["rememberMe"] != null)
            {
                CookieService.AuthenticateUser();
            }

            if (AuthenticationService.LoggedUser == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Account/Login?RedirectUrl=" + filterContext.HttpContext.Request.Url);
                filterContext.Result = new EmptyResult();
            }

            //if (HttpContext.Current.Session["LoggedUser"] != null)
            //{
            //    AnimalsParty.Models.User user = HttpContext.Current.Session["LoggedUser"] as AnimalsParty.Models.User;
            //    int a = 3;
            //}
            //else
            //{
            //    int b = 5;
            //}


        }
    }
}