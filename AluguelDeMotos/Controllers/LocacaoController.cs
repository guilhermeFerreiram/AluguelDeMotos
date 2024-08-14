using AluguelDeMotos.Enums;
using AluguelDeMotos.Filters;
using AluguelDeMotos.Helper;
using AluguelDeMotos.Models;
using AluguelDeMotos.Models.Usuarios;
using AluguelDeMotos.Models.ViewModel;
using AluguelDeMotos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AluguelDeMotos.Controllers
{
    [SomenteUsuarioLogado]
    public class LocacaoController : Controller
    {
        private readonly IMotoRepositorio _motoRepositorio;
        private readonly ISessao _sessao;
        private readonly ILocacaoRepositorio _locacaoRepositorio;
        private readonly IUsuarioRepositorio _usuariosRepositorio;
        public LocacaoController(IMotoRepositorio motoRepositorio,
                                 ISessao sessao,
                                 ILocacaoRepositorio locacaoRepositorio,
                                 IUsuarioRepositorio usuariosRepositorio)
        {
            _motoRepositorio = motoRepositorio;
            _sessao = sessao;
            _locacaoRepositorio = locacaoRepositorio;
            _usuariosRepositorio = usuariosRepositorio;
        }
        public IActionResult Index()
        {
            try
            {
                //Coleta e valida entregador
                var usuario = _sessao.BuscarSessaoUsuario();
                if (usuario == null) throw new Exception("Erro ao buscar sessão do usuário");

                if (usuario.Perfil != PerfilEnum.Entregador) throw new Exception("Somente entregadores podem alugar motos");
                var entregador = _usuariosRepositorio.BuscarEntregador(usuario.Id);
                if (entregador == null) throw new Exception("Erro ao buscar entregador");

                if (entregador.LocacaoAtiva != true) throw new Exception("O entregador não possui locação ativa");

                //Coleta e valida locação
                var locacao = _locacaoRepositorio.BuscarPorUsuarioId(entregador.Id);
                if (locacao == null) throw new Exception("Erro ao buscar locaçao do usuário");

                //Coleta e valida moto
                var moto = _motoRepositorio.BuscarPorId(locacao.MotoId);
                if (moto == null) throw new Exception("Erro ao buscar moto");

                LocacaoViewModel locacaoViewModel = new LocacaoViewModel
                {
                    Locacao = locacao,
                    Entregador = entregador,
                    Moto = moto
                };

                return View(locacaoViewModel);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;

                return RedirectToAction("MotosDisponiveis", "Moto");
            }

        }

        public IActionResult Alugar(LocacaoModel locacao)
        {
            try
            {
                locacao.DataLocacao = DateTime.Now;
                locacao.DefinirValorLocacao();

                _locacaoRepositorio.Adicionar(locacao);

                var moto = _motoRepositorio.BuscarPorId(locacao.MotoId);
                moto.Alugada = true;
                _motoRepositorio.Atualizar(moto);

                var entregador = _usuariosRepositorio.BuscarEntregador(locacao.UsuarioId);
                entregador.LocacaoAtiva = true;
                _usuariosRepositorio.AtualizarEntregador(entregador);

                TempData["MensagemSucesso"] = "Locação efetuada com sucesso!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message + e.StackTrace;

                if (e.InnerException != null)
                {
                    TempData["MensagemErro"] = e.InnerException.Message + e.InnerException.StackTrace;
                }

                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Planos(int id)
        {
            try
            {
                var usuario = _sessao.BuscarSessaoUsuario();
                if (usuario == null) throw new Exception("Erro ao buscar sessão do usuário");

                if (usuario.Perfil != PerfilEnum.Entregador) throw new Exception("Somente entregadores podem alugar motos");
                var entregador = _usuariosRepositorio.BuscarEntregador(usuario.Id);
                if (entregador == null) throw new Exception("Erro ao buscar entregador");
                if (!entregador.EstaAptoParaAlugar()) throw new Exception("Entregador não está apto para alugar");

                var moto = _motoRepositorio.BuscarPorId(id);
                if (moto == null) throw new Exception("Erro ao buscar moto por Id");
                if (moto.Alugada == true) throw new Exception("Esta moto não está disponível para aluguel");

                LocacaoModel locacao = new LocacaoModel
                {
                    MotoId = moto.Id,
                    UsuarioId = usuario.Id
                };

                return View(locacao);
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
