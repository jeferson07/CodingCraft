using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingCraft.Cap1.Controllers
{
    public class HomeController : Controller
    {
        [AuthorizeAttribute]
        public ActionResult Index()
        {
            return View();
        }
    }
}