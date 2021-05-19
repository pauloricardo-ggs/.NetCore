using SistemaGuincho.ValueObjects;

namespace SistemaGuincho.Interfaces
{
    public interface IGuincho
    {
        public int Id { get; set; }
        public Porte Porte { get; set; }
        public Status Status { get; set; }

        public void AlterarStatus(Status status);
        public void Socorrer(IVeiculo veiculo);
    }
}