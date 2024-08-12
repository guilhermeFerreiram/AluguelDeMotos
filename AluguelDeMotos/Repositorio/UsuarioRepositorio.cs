using AluguelDeMotos.Data;
using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;
        public UsuarioRepositorio(BancoContext context)
        {
            _context = context;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public bool Apagar(int id)
        {
            var usuarioDb = BuscarPorId(id);

            if (usuarioDb == null) throw new Exception("Houve um problema ao deletar o usuario");

            _context.Usuarios.Remove(usuarioDb);
            _context.SaveChanges();

            return true;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            var usuarioDb = BuscarPorId(usuario.Id);

            if (usuarioDb == null) throw new Exception("Houve um problema ao atualizar o usuário");

            usuarioDb.DataAtualizacao = DateTime.Now;

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Perfil = usuario.Perfil;

            _context.Usuarios.Update(usuarioDb);
            _context.SaveChanges();
            return usuarioDb;
        }

        public UsuarioModel BuscarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }
    }
}
