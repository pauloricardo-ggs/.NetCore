using SistemaGuincho.Interfaces;
using SistemaGuincho.ValueObjects;

namespace SistemaGuincho.Domain.Produtos
{
    public class Veiculo : VeiculoAbstrato
    {
        public Veiculo(Porte porte, int aroPneu, string modelo, string placa) : base(porte, aroPneu, modelo, placa) { }
    }
}
