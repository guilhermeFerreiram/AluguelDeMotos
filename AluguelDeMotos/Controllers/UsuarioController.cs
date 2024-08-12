using Microsoft.AspNetCore.Mvc;

namespace AluguelDeMotos.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
