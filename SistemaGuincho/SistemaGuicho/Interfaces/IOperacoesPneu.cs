namespace SistemaGuincho.Interfaces
{
    public interface IOperacoesPneu
    {
        void AlterarQuantidade();
        void AtualizarQuantidade(int Aro, int Quantidade);
        void CriarPneu(int Aro, int Quantidade);
        void Exibir();
    }
}