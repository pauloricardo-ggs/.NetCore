using SistemaGuincho.Domain.Produtos;
using SistemaGuincho.ValueObjects;

namespace SistemaGuincho.Interfaces
{
    public interface ITrocaPneu
    {
        VeiculoAbstrato CriarVeiculo(Porte porte, string modelo, string placa, int aroPneu);
        void RealizarTroca(IVeiculo veiculo);
        PneuAbstrato SelecionarPneu(int aroPneu);
    }
}