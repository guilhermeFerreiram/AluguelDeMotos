using AluguelDeMotos.Data;
using AluguelDeMotos.Enums;
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

        public UsuarioModel BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == email);
        }

        public List<UsuarioModel> BuscarTodos(PerfilEnum perfil)
        {
            return _context.Usuarios.Where(x => x.Perfil == perfil).ToList();
        }

        public UsuarioModel AtualizarEntregador(EntregadorModel entregador)
        {
            var usuarioDb = BuscarPorId(entregador.Id);

            if (usuarioDb == null) throw new Exception("Houve um problema ao atualizar o usuário");

            EntregadorModel entregadorDb = (EntregadorModel)usuarioDb;

            entregadorDb.DataAtualizacao = DateTime.Now;

            entregadorDb.Nome = entregador.Nome;
            entregadorDb.Email = entregador.Email;
            entregadorDb.Perfil = entregador.Perfil;
            entregadorDb.Cnpj = entregador.Cnpj;
            entregadorDb.Nascimento = entregador.Nascimento;
            entregadorDb.NumeroCnh = entregador.NumeroCnh;
            entregadorDb.TipoCnh = entregador.TipoCnh;

            _context.Usuarios.Update(entregadorDb);
            _context.SaveChanges();
            return entregadorDb;
        }

        public EntregadorModel BuscarEntregador(int id)
        {
            return _context.Usuarios.OfType<EntregadorModel>().FirstOrDefault(x => x.Id == id);
        }

        public AdminModel BuscarAdmin(int id)
        {
            return _context.Usuarios.OfType<AdminModel>().FirstOrDefault(x => x.Id == id);
        }
    }
}
