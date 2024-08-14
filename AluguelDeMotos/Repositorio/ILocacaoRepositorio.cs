using AluguelDeMotos.Models;

namespace AluguelDeMotos.Repositorio
{
    public interface ILocacaoRepositorio
    {
        public LocacaoModel Adicionar(LocacaoModel locacao);
        public LocacaoModel BuscarPorUsuarioId(int usuarioId);
    }
}
