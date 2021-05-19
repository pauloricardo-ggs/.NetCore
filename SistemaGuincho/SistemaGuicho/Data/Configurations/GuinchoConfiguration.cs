using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGuincho.Domain.Produtos;

namespace SistemaGuincho.Data.Configurations.Guinchos
{
    class GuinchoConfiguration : IEntityTypeConfiguration<Guincho>
    {
        public void Configure(EntityTypeBuilder<Guincho> builder)
        {
            builder.ToTable("Guinchos");
            builder.HasKey(guinchoPequeno => guinchoPequeno.Id);
            builder.Property(guinchoPequeno => guinchoPequeno.Porte).HasConversion<string>().IsRequired();
            builder.Property(guinchoPequeno => guinchoPequeno.Status).HasConversion<string>().IsRequired();
        }
    }
}
