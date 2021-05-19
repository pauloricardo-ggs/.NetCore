using SistemaGuincho.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGuincho.Domain.Produtos
{
    public abstract class PneuAbstrato : IPneu
    {
        [Key]
        public int Id { get; set; }
        public int Aro { get; set; }
        public int Quantidade { get; set; }

        public PneuAbstrato(int aro, int quantidade)
        {
            Aro = aro;
            Quantidade = quantidade;
        }

        public void AlterarQuantidade(int quantidade)
        {
            Quantidade += quantidade;
            if (Quantidade <= 0) { Quantidade = 0; }
        }

        public void TrocarPneu(IVeiculo veiculo)
        {
            Console.WriteLine($"Pneu de aro {Aro} colocado no carro de placa {veiculo.Placa}");
        }

        public void Imprimir()
        {
            Console.WriteLine(
                $"Id...........{Id}\n" +
                $"Aro..........{Aro}\n" +
                $"Quantidade...{Quantidade}");
        }
    }
}
