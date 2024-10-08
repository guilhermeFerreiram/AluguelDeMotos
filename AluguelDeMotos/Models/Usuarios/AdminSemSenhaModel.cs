﻿using AluguelDeMotos.Enums;
using System.ComponentModel.DataAnnotations;

namespace AluguelDeMotos.Models.Usuarios
{
    public class AdminSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do usuário obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Email do usuário obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Perfil do usuário obrigatório")]
        public PerfilEnum Perfil { get; set; }
    }
}
