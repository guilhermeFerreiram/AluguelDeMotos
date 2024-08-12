using AluguelDeMotos.Models;

namespace AluguelDeMotos.Repositorio
{
    public interface IMotoRepositorio
    {
        public MotoModel Adicionar(MotoModel moto);
        public List<MotoModel> BuscarTodos();
        public MotoModel BuscarPorId(int id);
    }
}
