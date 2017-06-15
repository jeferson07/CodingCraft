using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace CodingCraft.Cap2.Models
{
    public class LayoutChooserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                using (var context = new CodingCraftCap2Context())
                {
                    var userId = filterContext.HttpContext.User.Identity.GetUserId();
                    var user = context.Users.FirstOrDefault(u => u.Id == userId);
                    HttpContext.Current.Session["Layout"] = user.Layout;
                }


            }
        }
    }
}