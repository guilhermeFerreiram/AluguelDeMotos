using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        public UsuarioModel Adicionar(UsuarioModel usuario);
        public List<UsuarioModel> BuscarTodos();
        public UsuarioModel BuscarPorId(int id);
        UsuarioModel Atualizar(UsuarioModel usuario);
    }
}
