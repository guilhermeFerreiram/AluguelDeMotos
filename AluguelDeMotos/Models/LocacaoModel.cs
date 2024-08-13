﻿using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Models
{
    public class LocacaoModel
    {
        public int Id { get; set; }
        public DateTime? DataLocacao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int MotoId { get; set; }
        public MotoModel Moto { get; set; }
        public int EntregadorId { get; set; }
        public EntregadorModel Entregador { get; set; }
    }
}
