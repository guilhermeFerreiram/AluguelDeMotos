using AluguelDeMotos.Enums;
using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        public UsuarioModel Adicionar(UsuarioModel usuario);
        public List<UsuarioModel> BuscarTodos(PerfilEnum perfil);
        public UsuarioModel BuscarPorId(int id);
        public UsuarioModel Atualizar(UsuarioModel usuario);
        public bool Apagar(int id);
        public UsuarioModel BuscarPorEmail(string email);
        public UsuarioModel AtualizarEntregador(EntregadorModel usuario);
        public EntregadorModel BuscarEntregador(int id);
    }
}
