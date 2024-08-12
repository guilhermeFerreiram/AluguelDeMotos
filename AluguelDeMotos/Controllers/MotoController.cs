using AluguelDeMotos.Filters;
using AluguelDeMotos.Models;
using AluguelDeMotos.Models.Usuarios;
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
            try
            {
                var motos = _motoRepositorio.BuscarTodos();
                return View(motos);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index", "Home");
            }
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

        public IActionResult Editar(int id)
        {
            try
            {
                var moto = _motoRepositorio.BuscarPorId(id);
                return View(moto);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Alterar(MotoModel moto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _motoRepositorio.Atualizar(moto);
                    TempData["MensagemSucesso"] = "Moto editada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", moto);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            try
            {
                var moto = _motoRepositorio.BuscarPorId(id);
                return View(moto);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _motoRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Moto apagada com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
