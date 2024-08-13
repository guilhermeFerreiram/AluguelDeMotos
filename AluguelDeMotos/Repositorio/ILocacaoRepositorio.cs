using AluguelDeMotos.Models;
using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Repositorio
{
    public interface ILocacaoRepositorio
    {
        public LocacaoModel Adicionar(LocacaoModel locacao);
    }
}
