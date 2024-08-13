using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Helper
{
    public interface ISessao
    {
        public void CriarSessaoUsuario(UsuarioModel usuario);
        public UsuarioModel BuscarSessaoUsuario();
    }
}
