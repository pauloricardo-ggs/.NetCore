namespace SistemaGuincho.Interfaces
{
    interface IPneu
    {
        int Aro { get; set; }
        int Id { get; set; }
        int Quantidade { get; set; }

        void AlterarQuantidade(int Quantidade);
        void TrocarPneu(IVeiculo veiculo);
        void Imprimir();
    }
}