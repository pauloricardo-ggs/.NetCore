using SistemaGuincho.Domain;

namespace SistemaGuincho.Interfaces
{
    public interface ISocorro
    {
        Socorro CriarSocorro(IVeiculo Veiculo, IOperacoesGuincho OperacoesGuincho, IBanco Banco);
        void RealizarSocorro();
    }
}