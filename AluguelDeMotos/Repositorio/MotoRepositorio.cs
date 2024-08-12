using AluguelDeMotos.Data;
using AluguelDeMotos.Models;

namespace AluguelDeMotos.Repositorio
{
    public class MotoRepositorio : IMotoRepositorio
    {
        private readonly BancoContext _context;
        public MotoRepositorio(BancoContext context)
        {
            _context = context;
        }

        public MotoModel Adicionar(MotoModel moto)
        {
            _context.Motos.Add(moto);
            _context.SaveChanges();
            return moto;
        }

        public MotoModel BuscarPorId(int id)
        {
            return _context.Motos.FirstOrDefault(x => x.Id == id);
        }

        public List<MotoModel> BuscarTodos()
        {
            return _context.Motos.ToList();
        }
    }
}
