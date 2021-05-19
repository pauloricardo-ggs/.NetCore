using SistemaGuincho.Domain.Produtos;
using SistemaGuincho.Interfaces;
using System;

namespace SistemaGuincho.Domain.Operacoes
{
    class OperacoesPneu : IOperacoesPneu
    {
        private readonly IBanco Banco;
        private readonly IPegarDados PegarDados;

        public OperacoesPneu(IPegarDados PegarDados, IBanco Banco)
        {
            this.PegarDados = PegarDados;
            this.Banco = Banco;
        }

        public OperacoesPneu Iniciar(IPegarDados PegarDados, IBanco Banco)
        {
            return new OperacoesPneu(PegarDados, Banco);
        }

        public void AlterarQuantidade()
        {
            var Aro = PegarDados.PegarAro();
            var Quantidade = PegarDados.PegarQuantidade();
            AtualizarQuantidade(Aro, Quantidade);
        }

        public void AtualizarQuantidade(int Aro, int Quantidade)
        {
            foreach (var Pneu in Banco.Database().Pneu)
            {
                if (Pneu.Aro == Aro)
                {
                    Pneu.AlterarQuantidade(Quantidade);
                    goto salvar;
                }
            }
            CriarPneu(Aro, Quantidade);

        salvar:;
            Banco.Salvar();
        }

        public void CriarPneu(int Aro, int Quantidade)
        {
            Banco.Adicionar(new Pneu(Aro, Quantidade));
        }

        public void Exibir()
        {
            Console.WriteLine("PNEUS\n");
            foreach (var pneu in Banco.Database().Pneu)
            {
                pneu.Imprimir();
                Console.WriteLine("\n");
            }
        }
    }
}
