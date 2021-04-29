using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanosLigacao.Domain.Entities.Planos;

namespace PlanosLigacao.Infra.Data.Mapping.Planos
{
    public class CustoPlanoMapping : IEntityTypeConfiguration<CustoPlano>
    {
        public void Configure(EntityTypeBuilder<CustoPlano> builder)
        {
            builder.ToTable("Custo_Planos", "PlanosLigacao");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Origem)
                .IsRequired()
                .HasColumnType("char(3)");

            builder.Property(c => c.Destino)
                .IsRequired()
                .HasColumnType("char(3)");

            builder.Property(c => c.CustoMinuto)
                .IsRequired()
                .HasColumnName("Custo_Minuto")
                .HasColumnType("money");
        }
    }
}
