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
    }
}
