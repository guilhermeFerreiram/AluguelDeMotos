using AluguelDeMotos.Events;
using AluguelDeMotos.Models;
using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Repositorio
{
    public interface IMotoRepositorio
    {
        public MotoModel Adicionar(MotoModel moto);
        public List<MotoModel> BuscarTodos();
        public List<MotoModel> BuscarDisponiveis();
        public MotoModel BuscarPorId(int id);
        public MotoModel Atualizar(MotoModel moto);
        public bool Apagar(int id);
        public event EventHandler<MotoCadastradaEventArgs> MotoCadastrada;
    }
}
