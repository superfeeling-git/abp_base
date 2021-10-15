using Microsoft.AspNetCore.Mvc;

namespace IoT.MyProject.Web.Controllers
{
    public class HomeController : MyProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}