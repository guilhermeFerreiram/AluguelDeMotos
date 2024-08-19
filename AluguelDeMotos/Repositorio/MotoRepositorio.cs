using AluguelDeMotos.Data;
using AluguelDeMotos.Events;
using AluguelDeMotos.Models;

namespace AluguelDeMotos.Repositorio
{
    public class MotoRepositorio : IMotoRepositorio
    {
        private readonly BancoContext _context;
        public event EventHandler<MotoCadastradaEventArgs> MotoCadastrada;

        public MotoRepositorio(BancoContext context)
        {
            _context = context;
        }

        protected virtual void OnMotoCadastrada(MotoModel moto)
        {
            MotoCadastrada?.Invoke(this, new MotoCadastradaEventArgs(moto));
        }

        public MotoModel Adicionar(MotoModel moto)
        {
            _context.Motos.Add(moto);
            _context.SaveChanges();
            OnMotoCadastrada(moto);
            return moto;
        }

        public MotoModel Atualizar(MotoModel moto)
        {
            var motoDb = BuscarPorId(moto.Id);

            if (motoDb == null) throw new Exception("Houve um problema ao atualizar a moto");

            motoDb.Ano = moto.Ano;
            motoDb.Modelo = moto.Modelo;
            motoDb.Placa = moto.Placa;

            _context.Motos.Update(motoDb);
            _context.SaveChanges();
            return motoDb;
        }

        public MotoModel BuscarPorId(int id)
        {
            return _context.Motos.FirstOrDefault(x => x.Id == id);
        }

        public List<MotoModel> BuscarTodos()
        {
            return _context.Motos.ToList();
        }

        public bool Apagar(int id)
        {
            var motoDb = BuscarPorId(id);

            if (motoDb == null) throw new Exception("Houve um problema ao deletar a moto");

            _context.Motos.Remove(motoDb);
            _context.SaveChanges();

            return true;
        }

        public List<MotoModel> BuscarDisponiveis()
        {
            return _context.Motos.Where(x => x.Alugada == false).ToList();
        }
    }
}
