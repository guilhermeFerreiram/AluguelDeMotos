using AluguelDeMotos.Enums;
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
            try
            {
                var adminDb = _usuarioRepositorio.BuscarPorEmail("admin@example.com");
                if (adminDb == null)
                {
                    var admin = new AdminModel
                    {
                        Nome = "Adimn",
                        Email = "admin@example.com",
                        Perfil = PerfilEnum.Admin,
                        Senha = "1234"
                    };

                    _usuarioRepositorio.Adicionar(admin);
                }

                return View();
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index");
            }
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

                            switch (usuario.Perfil)
                            {
                                case PerfilEnum.Entregador:
                                    return RedirectToAction("MotosDisponiveis", "Moto");

                                case PerfilEnum.Admin:
                                    return RedirectToAction("Index", "Moto");
                            }
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

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
        }
    }
}
