using AluguelDeMotos.Filters;
using AluguelDeMotos.Models.Usuarios;
using AluguelDeMotos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AluguelDeMotos.Controllers
{
    [SomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            try
            {
                var usuarios = _usuarioRepositorio.BuscarTodos();
                return View(usuarios);
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
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário criado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
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
                var usuario = _usuarioRepositorio.BuscarPorId(id);
                return View(usuario);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenha)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil
                    };

                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);
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
                var usuario = _usuarioRepositorio.BuscarPorId(id);
                return View(usuario);
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
                _usuarioRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
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
