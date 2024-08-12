using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        public UsuarioModel Adicionar(UsuarioModel usuario);
        public List<UsuarioModel> BuscarTodos();
        public UsuarioModel BuscarPorId(int id);
        public UsuarioModel Atualizar(UsuarioModel usuario);
        public bool Apagar(int id);
        public UsuarioModel BuscarPorEmail(string email);
    }
}
