using Microsoft.AspNet.Mvc;

namespace Microservices.WebViews
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
