using SistemaGuincho.Domain.Produtos;
using SistemaGuincho.Interfaces;
using SistemaGuincho.ValueObjects;

namespace SistemaGuincho.Domain.Fabricas
{
    class SocorroVeicularGrande : SocorroVeicular
    {
        private readonly IBanco Banco;

        public SocorroVeicularGrande(IBanco Banco)
        {
            this.Banco = Banco;
        }

        public override VeiculoAbstrato CriarVeiculo(string modelo, string placa, int aroPneu)
        {
            return new Veiculo(Porte.Grande, aroPneu, modelo, placa);
        }

        public override GuinchoAbstrato SelecionarGuincho()
        {
            foreach (var guincho in Banco.Database().Guincho)
            {
                if (guincho.Porte == Porte.Grande && guincho.Status == Status.Disponivel)
                {
                    return guincho;
                }
            }
            return null;
        }
    }
}
