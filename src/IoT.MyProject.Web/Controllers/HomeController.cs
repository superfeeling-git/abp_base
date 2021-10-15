using Microsoft.AspNetCore.Mvc;

namespace IoT.MyProject.Web.Controllers
{
    public class HomeController : MyProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}