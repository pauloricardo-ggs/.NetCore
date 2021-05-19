using Microsoft.EntityFrameworkCore;
using SistemaGuincho.Domain.Produtos;
using SistemaGuincho.Interfaces;
using SistemaGuincho.ValueObjects;
using System;

namespace SistemaGuincho.Domain.Operacoes
{
    class OperacoesGuincho : IOperacoesGuincho
    {
        private readonly IBanco Banco;
        private readonly IPegarDados PegarDados;

        public OperacoesGuincho(IPegarDados PegarDados, IBanco Banco)
        {
            this.PegarDados = PegarDados;
            this.Banco = Banco;
        }

        public bool AlterarStatus()
        {
            var Id = PegarDados.PegarId();
            var Status = PegarDados.PegarStatus();
            return AtualizarStatus(Id, Status);
        }

        public bool AtualizarStatus(int Id, Status Status)
        {
            var Guincho = Banco.Database().Guincho.Find(Id);
            if (Guincho == null) { return false; }
            Guincho.AlterarStatus(Status);
            Banco.Salvar();
            return true;
        }

        public void Adicionar()
        {
            var Guincho = PegarDados.PegarGuincho();
            Console.WriteLine("\nProcessando...");
            Banco.Adicionar(Guincho);
            Banco.Salvar();
        }

        public void Remover()
        {
            var Id = PegarDados.PegarId();

            var Guincho = Banco.Database().Guincho.Find(Id);
            if (Guincho != null) { Banco.Database().Entry(Guincho).State = EntityState.Deleted; }
            Banco.Salvar();
        }

        public void Exibir()
        {
            Console.WriteLine("GUINCHOS\n");
            foreach (var guincho in Banco.Database().Guincho)
            {
                guincho.Imprimir();
                Console.WriteLine("\n");
            }
        }
    }
}
