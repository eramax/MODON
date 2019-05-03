using System.Web.Mvc;

namespace Web.App_Start
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Facility");
        }
    }
}