using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanosLigacao.Domain.Entities.Planos;

namespace PlanosLigacao.Infra.Data.Mapping.Planos
{
    public class PlanoMapping : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable("Planos", "PlanosLigacao");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomePlano)
                .IsRequired()
                .HasColumnName("Nome_Plano")
                .HasColumnType("varchar(50)");

            builder.Property(c => c.TempoPlano)
                .IsRequired()
                .HasColumnName("Tempo_Plano")
                .HasColumnType("int");
        }
    }
}
