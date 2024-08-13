using System.ComponentModel.DataAnnotations;

namespace AluguelDeMotos.Models.Usuarios
{
    public class EntregadorModel : UsuarioModel
    {
        [Required(ErrorMessage = "CNPJ do entregador obrigatório")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido. Use o formato 99.999.999/0001-99")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Data de nascimento do entregador obrigatória")]
        public DateTime Nascimento { get; set; }
        [Required(ErrorMessage = "CNH do entregador obrigatório")]
        public CnhModel Cnh { get; set; }
    }
}
