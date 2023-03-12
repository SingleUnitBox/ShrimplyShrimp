using Microsoft.AspNetCore.Mvc;

namespace ShrimplyShrimpWeb.Controllers
{
    public class ShrimpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
