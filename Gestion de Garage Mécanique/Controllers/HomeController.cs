using System.Web.Mvc;

namespace Gestion_de_Garage_Mécanique.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
