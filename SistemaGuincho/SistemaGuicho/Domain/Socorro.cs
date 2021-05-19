using SistemaGuincho.Domain.Fabricas;
using SistemaGuincho.Domain.Produtos;
using SistemaGuincho.Interfaces;
using SistemaGuincho.ValueObjects;
using System;

namespace SistemaGuincho.Domain
{
    public class Socorro : ISocorro
    {
        private readonly VeiculoAbstrato _veiculo;
        private readonly GuinchoAbstrato _guincho;
        private IOperacoesGuincho OperacoesGuincho;
        private IBanco Banco;

        public Socorro() { }

        public Socorro(SocorroVeicular socorroVeicular, IVeiculo veiculo, IOperacoesGuincho OperacoesGuincho, IBanco Banco)
        {
            _veiculo = socorroVeicular.CriarVeiculo(veiculo.Modelo, veiculo.Placa, veiculo.AroPneu);
            _guincho = socorroVeicular.SelecionarGuincho();
            this.OperacoesGuincho = OperacoesGuincho;
            this.Banco = Banco;
        }

        public Socorro CriarSocorro(IVeiculo veiculo, IOperacoesGuincho OperacoesGuincho, IBanco Banco)
        {
            switch (veiculo.Porte)
            {
                case Porte.Pequeno:
                    return new Socorro(new SocorroVeicularPequeno(Banco), veiculo, OperacoesGuincho, Banco);
                case Porte.Medio:
                    return new Socorro(new SocorroVeicularMedio(Banco), veiculo, OperacoesGuincho, Banco);
                case Porte.Grande:
                    return new Socorro(new SocorroVeicularGrande(Banco), veiculo, OperacoesGuincho, Banco);
                default:
                    throw new ApplicationException("Não foi possível identificar o veículo");
            }
        }

        public void RealizarSocorro()
        {
            Console.Clear();
            if (_guincho == null) { Console.WriteLine($"Não há nenhum guincho disponível para veículos desse porte."); }
            else
            {
                _guincho.Socorrer(_veiculo);
                OperacoesGuincho.AtualizarStatus(_guincho.Id, Status.Indisponivel);
            }
        }
    }
}
