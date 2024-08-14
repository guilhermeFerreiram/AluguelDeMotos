using AluguelDeMotos.Data;
using AluguelDeMotos.Models;
using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Repositorio
{
    public class LocacaoRepositorio : ILocacaoRepositorio
    {
        private readonly BancoContext _context;
        public LocacaoRepositorio(BancoContext context)
        {
            _context = context;
        }

        public LocacaoModel Adicionar(LocacaoModel locacao)
        {
            _context.Locacoes.Add(locacao);
            _context.SaveChanges();
            return locacao;
        }

        public LocacaoModel BuscarPorUsuarioId(int usuarioId)
        {
            return _context.Locacoes.FirstOrDefault(x => x.UsuarioId == usuarioId);
        }

        public LocacaoModel BuscarPorId(int id)
        {
            return _context.Locacoes.FirstOrDefault(x => x.Id == id);
        }

        public bool Apagar(int id)
        {
            var locacaoDb = BuscarPorId(id);
            if (locacaoDb == null) throw new Exception("Houve um problema ao deletar a moto");

            _context.Locacoes.Remove(locacaoDb);
            _context.SaveChanges();

            return true;
        }
    }
}
