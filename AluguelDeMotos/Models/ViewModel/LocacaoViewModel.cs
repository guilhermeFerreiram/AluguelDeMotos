using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Models.ViewModel
{
    public class LocacaoViewModel
    {
        public LocacaoModel Locacao { get; set; }
        public EntregadorModel Entregador { get; set; }
        public MotoModel Moto { get; set; }
    }
}
