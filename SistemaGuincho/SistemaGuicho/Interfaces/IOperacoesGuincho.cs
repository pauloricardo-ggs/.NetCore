using SistemaGuincho.ValueObjects;

namespace SistemaGuincho.Interfaces
{
    public interface IOperacoesGuincho
    {
        void Adicionar();
        bool AlterarStatus();
        bool AtualizarStatus(int Id, Status Status);
        void Exibir();
        void Remover();
    }
}