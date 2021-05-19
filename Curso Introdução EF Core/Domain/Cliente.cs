using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEFCoreProj.Domain
{
    [Table("Clientes")]                                             // no meu banco de dados nao e cliente e sim clientes
    public class Cliente
    {
        [Key]                                                       // atributo chave da entidade
        public int Id { get; set; }

        [Required]                                                  // atributo obrigatorio
        public string Nome { get; set; }

        [Column("Phone")]                                           // na hora que for inserir ou ler alguma informacao para essa propriedade, o nome do campo nao e telefone e sim phone
        public string Telefone { get; set; }
        
        public string CEP { get; set; }
        
        public string Cidade { get; set; }
        
        public string Estado { get; set; }
    }
}