using Microsoft.AspNetCore.Mvc;

namespace NET_293_T26.Controllers
{
    public class Hom : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
