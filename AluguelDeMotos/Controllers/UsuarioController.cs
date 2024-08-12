using AluguelDeMotos.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace AluguelDeMotos.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
    }
}
