using AluguelDeMotos.Helper;
using AluguelDeMotos.Models.Usuarios;
using AluguelDeMotos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AluguelDeMotos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                               ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entrar(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _usuarioRepositorio.BuscarPorEmail(login.Email);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(login.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = "Senha inválida. Tente novamente.";
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Login e/ou senha inválidos. Tente novamente.";
                    }
                }

                return View("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
