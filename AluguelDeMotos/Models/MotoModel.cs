using AluguelDeMotos.Enums;
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
        public string Placa { get; set; }
    }
}
