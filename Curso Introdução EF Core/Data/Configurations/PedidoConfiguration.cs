using CursoEFCoreProj.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCoreProj.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
                builder.ToTable("Pedidos");
                builder.HasKey(p => p.Id);
                builder.Property(p => p.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                builder.Property(p => p.Status).HasConversion<string>();
                builder.Property(p => p.TipoFrete).HasConversion<int>();
                builder.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

                // relacionamento de muitos para um
                builder.HasMany(p => p.Itens) // tenho muitos itens
                    .WithOne(p => p.Pedido) // para um pedido
                    .OnDelete(DeleteBehavior.Cascade); // cascade - quando eu deletar um pedido, os itens desse pedido tambem serao deletados // retrict - primeiro delete os itens para poder deletar o pedido
        }
    }
}