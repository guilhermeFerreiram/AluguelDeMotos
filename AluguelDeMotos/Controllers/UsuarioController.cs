using AluguelDeMotos.Models.Usuarios;
using AluguelDeMotos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AluguelDeMotos.Controllers
{
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
            catch (Exception)
            {
                throw;
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
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IActionResult Editar(int id)
        {
            try
            {
                var usuario = _usuarioRepositorio.BuscarPorId(id);
                return View(usuario);
            }
            catch (Exception)
            {
                throw;
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
                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            try
            {
                var usuario = _usuarioRepositorio.BuscarPorId(id);
                return View(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
