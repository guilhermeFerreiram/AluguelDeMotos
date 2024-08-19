using AluguelDeMotos.Models;

namespace AluguelDeMotos.Events
{
    public class MotoCadastradaEventArgs : EventArgs
    {
        public MotoModel Moto { get; set; }

        public MotoCadastradaEventArgs(MotoModel moto)
        {
            Moto = moto;
        }
    }
}
