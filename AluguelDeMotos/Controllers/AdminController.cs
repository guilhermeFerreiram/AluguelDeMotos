using AluguelDeMotos.Enums;
using AluguelDeMotos.Filters;
using AluguelDeMotos.Helper;
using AluguelDeMotos.Models.Usuarios;
using AluguelDeMotos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AluguelDeMotos.Controllers
{
    [SomenteAdmin]
    public class AdminController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public AdminController(IUsuarioRepositorio usuarioRepositorio,
                               ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            try
            {
                var usuarios = _usuarioRepositorio.BuscarTodos(PerfilEnum.Admin);
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
        public IActionResult Criar(AdminModel admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(admin);
                    TempData["MensagemSucesso"] = "Usuário criado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(admin);
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
                var usuario = _sessao.BuscarSessaoUsuario();
                if (usuario == null) throw new Exception("Erro ao encontrar sessao do usuário");
                if (usuario.Id != id) throw new Exception("Você pode editar apenas seu perfil");

                var admin = _usuarioRepositorio.BuscarAdmin(usuario.Id);

                return View(admin);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Alterar(AdminSemSenhaModel adminSemSenha)
        {
            try
            {
                UsuarioModel admin = null;

                if (ModelState.IsValid)
                {
                    admin = new AdminModel()
                    {
                        Id = adminSemSenha.Id,
                        Nome = adminSemSenha.Nome,
                        Email = adminSemSenha.Email,
                        Perfil = adminSemSenha.Perfil
                    };

                    _usuarioRepositorio.Atualizar(admin);
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", admin);
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
                var usuario = _sessao.BuscarSessaoUsuario();
                if (usuario == null) throw new Exception("Erro ao encontrar sessao do usuário");
                if (usuario.Id != id) throw new Exception("Você pode apagar apenas seu perfil");

                var admin = _usuarioRepositorio.BuscarAdmin(usuario.Id);

                return View(admin);
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
