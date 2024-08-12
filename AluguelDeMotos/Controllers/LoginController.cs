using Microsoft.AspNetCore.Mvc;

namespace AluguelDeMotos.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
