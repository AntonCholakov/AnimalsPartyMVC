using AnimalsParty.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalsParty.Controllers
{
    [AuthenticationFilter]
    public class BaseController : Controller
    {
    }
}