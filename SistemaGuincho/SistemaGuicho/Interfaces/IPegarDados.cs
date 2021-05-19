using SistemaGuincho.Domain.Produtos;
using SistemaGuincho.ValueObjects;

namespace SistemaGuincho.Interfaces
{
    public interface IPegarDados
    {
        int PegarAro();
        GuinchoAbstrato PegarGuincho();
        int PegarId();
        string PegarModelo();
        string PegarPlaca();
        Porte PegarPorte();
        int PegarQuantidade();
        Status PegarStatus();
        VeiculoAbstrato PegarVeiculo();
    }
}