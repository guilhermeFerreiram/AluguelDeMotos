using AluguelDeMotos.Models;

namespace AluguelDeMotos.Repositorio
{
    public interface ILocacaoRepositorio
    {
        public LocacaoModel Adicionar(LocacaoModel locacao);
        public LocacaoModel BuscarPorUsuarioId(int usuarioId);
        public LocacaoModel BuscarPorId(int id);
        public bool Apagar(int id);
    }
}
