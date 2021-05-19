using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGuincho.Domain.Produtos;

namespace SistemaGuincho.Data.Configurations
{
    class PneuConfiguration : IEntityTypeConfiguration<Pneu>
    {
        public void Configure(EntityTypeBuilder<Pneu> builder)
        {
            builder.ToTable("Pneus");
            builder.HasKey(pneu => pneu.Id);
            builder.Property(pneu => pneu.Aro).IsRequired();
            builder.Property(pneu => pneu.Quantidade).IsRequired();
        }
    }
}
