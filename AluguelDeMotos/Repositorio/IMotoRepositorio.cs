﻿using AluguelDeMotos.Models;
using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Repositorio
{
    public interface IMotoRepositorio
    {
        public MotoModel Adicionar(MotoModel moto);
        public List<MotoModel> BuscarTodos();
    }
}
