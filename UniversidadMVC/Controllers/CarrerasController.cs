using Microsoft.AspNetCore.Mvc;

namespace UniversidadMVC.Controllers
{
    public class CarrerasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
