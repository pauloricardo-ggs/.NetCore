using SistemaGuincho.Data;
using SistemaGuincho.Interfaces;
using System;

namespace SistemaGuincho.Domain.Produtos
{
    class Banco : IBanco
    {
        public ApplicationContext database = new ApplicationContext();

        public void Salvar()
        {
            database.SaveChanges();
        }

        public void Adicionar(Object Objeto)
        {
            database.Add(Objeto);
        }

        public ApplicationContext Database()
        {
            return database;
        }
    }
}
