using AluguelDeMotos.Enums;
using AluguelDeMotos.Helper;
using AluguelDeMotos.Models;
using AluguelDeMotos.Models.Usuarios;
using AluguelDeMotos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AluguelDeMotos.Controllers
{
    public class LocacaoController : Controller
    {
        private readonly IMotoRepositorio _motoRepositorio;
        private readonly ISessao _sessao;
        private readonly ILocacaoRepositorio _locacaoRepositorio;
        public LocacaoController(IMotoRepositorio motoRepositorio,
                                 ISessao sessao,
                                 ILocacaoRepositorio locacaoRepositorio)
        {
            _motoRepositorio = motoRepositorio;
            _sessao = sessao;
            _locacaoRepositorio = locacaoRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Alugar(int id) //Se usuário já tiver uma moto alugada, gerar exceção; Conferir habilitação
        {
            try
            {
                var usuario = _sessao.BuscarSessaoUsuario();

                if (usuario == null) throw new Exception("Erro ao buscar sessão do usuário");

                if (usuario.Perfil != PerfilEnum.Entregador) throw new Exception("Somente entregadores podem alugar motos");

                var moto = _motoRepositorio.BuscarPorId(id);

                if (moto == null) throw new Exception("Erro ao buscar moto por Id");

                if (moto.Alugada == true) throw new Exception("Esta moto não está disponível para aluguel");

                LocacaoModel locacao = new LocacaoModel
                {
                    MotoId = moto.Id,
                    UsuarioId = usuario.Id,
                    DataLocacao = DateTime.Now
                };

                _locacaoRepositorio.Adicionar(locacao);

                moto.Alugada = true;
                _motoRepositorio.Atualizar(moto);

                TempData["MensagemSucesso"] = "Locação efetuada com sucesso!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;

                if (e.InnerException != null)
                {
                    TempData["MensagemErro"] = e.InnerException.Message;
                }

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
