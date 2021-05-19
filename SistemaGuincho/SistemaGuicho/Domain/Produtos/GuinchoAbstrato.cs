using SistemaGuincho.Interfaces;
using SistemaGuincho.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGuincho.Domain.Produtos
{
    public abstract class GuinchoAbstrato : IGuincho
    {
        [Key]
        public int Id { get; set; }
        public Porte Porte { get; set; }
        public Status Status { get; set; }

        public GuinchoAbstrato(Porte porte, Status status)
        {
            Porte = porte;
            Status = status;
        }

        public void AlterarStatus(Status status)
        {
            Status = status;
        }

        public void Socorrer(IVeiculo veiculo)
        {
            Console.WriteLine($"O guincho {Id} de porte {Porte} está socorrendo o carro de placa {veiculo.Placa}.\n");
        }

        public void Imprimir()
        {
            Console.WriteLine(
                $"Id.......{Id}\n" +
                $"Porte....{Porte}\n" +
                $"Status...{Status}");
        }
    }
}
