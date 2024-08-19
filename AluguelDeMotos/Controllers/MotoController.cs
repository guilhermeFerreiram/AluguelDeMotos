using AluguelDeMotos.Events;
using AluguelDeMotos.Filters;
using AluguelDeMotos.Mensageria;
using AluguelDeMotos.Models;
using AluguelDeMotos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AluguelDeMotos.Controllers
{
    public class MotoController : Controller
    {
        private readonly IMotoRepositorio _motoRepositorio;
        private readonly IRabbitMQService _rabbitMQService;
        public MotoController(IMotoRepositorio motoRepositorio,
                              IRabbitMQService rabbitMQService)
        {
            _motoRepositorio = motoRepositorio;
            _rabbitMQService = rabbitMQService;

            _motoRepositorio.MotoCadastrada += HandleMotoCadastradaEvent;
        }

        private void HandleMotoCadastradaEvent(object sender, MotoCadastradaEventArgs e)
        {
            if (e.Moto.Ano == 2024)
            {
                _rabbitMQService.PostMessage($"Nova moto 2024 cadastrada!");
            }
        }

        [SomenteAdmin]
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

        [SomenteUsuarioLogado]
        public IActionResult MotosDisponiveis()
        {
            try
            {
                var motos = _motoRepositorio.BuscarDisponiveis();
                return View(motos);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [SomenteAdmin]
        public IActionResult Criar()
        {
            return View();
        }

        [SomenteAdmin]
        [HttpPost]
        public IActionResult Criar(MotoModel moto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    moto.Alugada = false;
                    _motoRepositorio.Adicionar(moto);
                    TempData["MensagemSucesso"] = "Moto criada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(moto);
            }
            catch (DbUpdateException e)
            {
                TempData["MensagemErro"] = e.Message;

                if (e.InnerException != null)
                {
                    TempData["MensagemErro"] = e.InnerException.Message;
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        [SomenteAdmin]
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

        [SomenteAdmin]
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
            catch (DbUpdateException e)
            {
                TempData["MensagemErro"] = e.Message;

                if (e.InnerException != null)
                {
                    TempData["MensagemErro"] = e.InnerException.Message;
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        [SomenteAdmin]
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

        [SomenteAdmin]
        public IActionResult Apagar(int id)
        {
            try
            {
                var moto = _motoRepositorio.BuscarPorId(id);
                if (moto == null) throw new Exception("Erro ao buscar moto");

                if (moto.Alugada == true) throw new Exception("Esta moto está alugada e, portanto, não pode ser apagada do banco de dados");

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
