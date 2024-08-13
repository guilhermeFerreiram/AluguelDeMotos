using AluguelDeMotos.Enums;
using System.ComponentModel.DataAnnotations;

namespace AluguelDeMotos.Models.Usuarios
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do usuário obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Email do usuário obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Perfil do usuário obrigatório")]
        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "Senha do usuário obrigatória")]
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
