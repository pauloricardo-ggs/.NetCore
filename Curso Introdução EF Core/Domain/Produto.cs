using System.ComponentModel.DataAnnotations;
using CursoEFCoreProj.ValueObjects;

namespace CursoEFCoreProj.Domain
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public bool Ativo { get; set; }
    }
}