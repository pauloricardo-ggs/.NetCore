using SistemaGuincho.Interfaces;
using SistemaGuincho.ValueObjects;

namespace SistemaGuincho.Domain.Produtos
{
    public abstract class VeiculoAbstrato : IVeiculo
    {
        public Porte Porte { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int AroPneu { get; set; }

        public VeiculoAbstrato(Porte porte, int aroPneu, string modelo, string placa)
        {
            Porte = porte;
            AroPneu = aroPneu;
            Modelo = modelo;
            Placa = placa;
        }
    }
}
