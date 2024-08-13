using AluguelDeMotos.Enums;
using System.ComponentModel.DataAnnotations;

namespace AluguelDeMotos.Models.Usuarios
{
    public class EntregadorModel : UsuarioModel
    {
        [Required(ErrorMessage = "CNPJ do entregador obrigatório")]
        [MaxLength(18)]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido. Use o formato 99.999.999/0001-99")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Data de nascimento do entregador obrigatória")]
        public DateTime Nascimento { get; set; }
        [Required(ErrorMessage = "Numero CNH obrigatório")]
        [MaxLength(11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Número de CNH inválido.")]
        public string NumeroCnh { get; set; }
        [Required(ErrorMessage = "Tipo CNH obrigatório")]
        public CnhEnum TipoCnh { get; set; }
    }
}
