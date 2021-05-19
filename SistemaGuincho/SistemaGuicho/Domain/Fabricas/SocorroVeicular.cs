using SistemaGuincho.Domain.Produtos;

namespace SistemaGuincho.Domain.Fabricas
{
    public abstract class SocorroVeicular
    {
        public abstract VeiculoAbstrato CriarVeiculo(string modelo, string placa, int aroPneu);
        public abstract GuinchoAbstrato SelecionarGuincho();
    }
}
