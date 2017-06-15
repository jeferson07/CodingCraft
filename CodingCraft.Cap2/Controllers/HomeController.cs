using CodingCraft.Cap2.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingCraft.Cap2.Controllers
{
    public class HomeController : Controller
    {
        private CodingCraftCap2Context context = new CodingCraftCap2Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChangeLayout(string layout, string returnUrl)
        {
            Session["Layout"] = layout;
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                user.Layout = layout;
                context.SaveChanges();
            }

            return Redirect(returnUrl);
        }
    }
}