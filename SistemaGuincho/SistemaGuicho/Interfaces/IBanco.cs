using SistemaGuincho.Data;

namespace SistemaGuincho.Interfaces
{
    public interface IBanco
    {
        void Adicionar(object Objeto);
        void Salvar();
        ApplicationContext Database();
    }
}