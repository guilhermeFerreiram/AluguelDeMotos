using AluguelDeMotos.Enums;
using AluguelDeMotos.Models.Usuarios;
using System.ComponentModel.DataAnnotations;

namespace AluguelDeMotos.Models
{
    public class MotoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ano obrigatório")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "Modelo obrigatório")]
        public ModeloEnum Modelo { get; set; }
        [Required(ErrorMessage = "Placa obrigatória")]
        [MaxLength(8)]
        [RegularExpression(@"^[A-Z]{3}-\d{1}[A-Z0-9]{1}\d{2}$", ErrorMessage = "A placa deve estar no formato ABC-1234 ou ABC-1D23.")]
        public string Placa { get; set; }
        public LocacaoModel? Locacao { get; set; }
        public bool? Alugada { get; set; }

    }
}
