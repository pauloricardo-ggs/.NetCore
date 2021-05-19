using SistemaGuincho.ValueObjects;

namespace SistemaGuincho.Interfaces
{
    public interface IVeiculo
    {
        public int AroPneu { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public Porte Porte { get; set; }
    }
}