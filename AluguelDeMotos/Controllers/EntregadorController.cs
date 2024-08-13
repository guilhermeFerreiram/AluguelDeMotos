using AluguelDeMotos.Enums;
using AluguelDeMotos.Filters;
using AluguelDeMotos.Models.Usuarios;
using AluguelDeMotos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AluguelDeMotos.Controllers
{
    [SomenteAdmin]
    public class EntregadorController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public EntregadorController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            try
            {
                List<EntregadorModel> entregadores = new();

                var usuarios = _usuarioRepositorio.BuscarTodos(PerfilEnum.Entregador);

                for (int i = 0; i < usuarios.Count; i++)
                {
                    EntregadorModel entregador = (EntregadorModel)usuarios[i];
                    entregadores.Add(entregador);
                }

                return View(entregadores);
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
        public IActionResult Criar(EntregadorModel admin)
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

        public IActionResult Alterar(EntregadorSemSenhaModel entregadorSemSenha)
        {
            try
            {
                EntregadorModel entregador = null;

                if (ModelState.IsValid)
                {
                    entregador = new EntregadorModel()
                    {
                        Id = entregadorSemSenha.Id,
                        Nome = entregadorSemSenha.Nome,
                        Email = entregadorSemSenha.Email,
                        Perfil = entregadorSemSenha.Perfil,
                        Cnpj = entregadorSemSenha.Cnpj,
                        Nascimento = entregadorSemSenha.Nascimento,
                        NumeroCnh = entregadorSemSenha.NumeroCnh,
                        TipoCnh = entregadorSemSenha.TipoCnh
                    };

                    _usuarioRepositorio.AtualizarEntregador(entregador);
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", entregador);
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
