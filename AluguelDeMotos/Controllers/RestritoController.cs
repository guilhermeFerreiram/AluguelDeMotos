using AluguelDeMotos.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AluguelDeMotos.Controllers
{
    [SomenteUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
