using Microsoft.AspNetCore.Mvc;

namespace AluguelDeMotos.Controllers
{
    public class MotoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
