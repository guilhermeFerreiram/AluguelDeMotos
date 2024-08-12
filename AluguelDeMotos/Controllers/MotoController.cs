using AluguelDeMotos.Filters;
using AluguelDeMotos.Models;
using AluguelDeMotos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AluguelDeMotos.Controllers
{
    [SomenteAdmin]
    public class MotoController : Controller
    {
        private readonly IMotoRepositorio _motoRepositorio;
        public MotoController(IMotoRepositorio motoRepositorio)
        {
            _motoRepositorio = motoRepositorio;
        }

        public IActionResult Index()
        {
            var motos = _motoRepositorio.BuscarTodos();
            return View(motos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(MotoModel moto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _motoRepositorio.Adicionar(moto);
                    TempData["MensagemSucesso"] = "Moto criada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(moto);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
