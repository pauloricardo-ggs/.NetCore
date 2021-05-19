using SistemaGuincho.Interfaces;
using SistemaGuincho.Domain.Produtos;
using SistemaGuincho.ValueObjects;
using System;

namespace SistemaGuincho.Domain
{
    public class TrocaPneu : ITrocaPneu
    {
        private VeiculoAbstrato Veiculo;
        private PneuAbstrato Pneu;
        private readonly IOperacoesPneu OperacoesPneu;
        private readonly IBanco Banco;

        public TrocaPneu(IOperacoesPneu OperacoesPneu, IBanco Banco)
        {
            this.OperacoesPneu = OperacoesPneu;
            this.Banco = Banco;
        }

        public void Iniciar(IVeiculo veiculo)
        {
            Veiculo = CriarVeiculo(veiculo.Porte, veiculo.Modelo, veiculo.Placa, veiculo.AroPneu);
            Pneu = SelecionarPneu(veiculo.AroPneu);
        }

        public VeiculoAbstrato CriarVeiculo(Porte porte, string modelo, string placa, int aroPneu)
        {
            return new Veiculo(porte, aroPneu, modelo, placa);
        }

        public PneuAbstrato SelecionarPneu(int aroPneu)
        {
            foreach (var pneu in Banco.Database().Pneu)
            {
                if (pneu.Aro == aroPneu && pneu.Quantidade >= 0)
                {
                    return pneu;
                }
            }
            return null;
        }

        public void RealizarTroca(IVeiculo veiculo)
        {
            Iniciar(veiculo);
            Console.Clear();
            if (Pneu == null || Pneu.Quantidade == 0) { Console.WriteLine($"Não há nenhum pneu desse aro disponível."); }
            else
            {
                Pneu.TrocarPneu(Veiculo);
                OperacoesPneu.AtualizarQuantidade(Pneu.Aro, -1);
            }
        }
    }
}
