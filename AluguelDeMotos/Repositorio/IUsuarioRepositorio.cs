using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        public UsuarioModel Adicionar(UsuarioModel usuario);
    }
}
