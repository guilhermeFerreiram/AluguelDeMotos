using AluguelDeMotos.Enums;
using System.ComponentModel.DataAnnotations;

namespace AluguelDeMotos.Models
{
    public class CnhModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Numero CNH obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Número de CNH inválido.")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Tipo CNH obrigatório")]
        public CnhEnum Tipo { get; set; }
    }
}
