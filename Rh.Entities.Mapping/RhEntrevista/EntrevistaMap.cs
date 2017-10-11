using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rh.Entities.RhEntrevista;

namespace Rh.Entities.Mapping.RhEntrevista
{
    public class EntrevistaMap : IEntityTypeConfiguration<Entrevista>
    {
        public void Configure(EntityTypeBuilder<Entrevista> builder)
        {
            // Primary Key
            builder.HasKey(t => t.EntrevistaId);


            // Table & Column Mappings
            builder.ToTable("Entrevista", "RhEntrevista");
            builder.Property(t => t.EntrevistaId).HasColumnName("EntrevistaId");
            builder.Property(t => t.CandidatoId).HasColumnName("CandidatoId");
            builder.Property(t => t.DataEntrevista).HasColumnName("DataEntrevista");

            // Relationships
            builder.HasOne(t => t.Vaga)
                .WithMany(t => t.ListaEntrevista)
                .HasForeignKey(t => t.VagaId);

            builder.HasOne(t => t.Candidato)
                .WithMany(t => t.ListaEntrevista)
                .HasForeignKey(t => t.CandidatoId);
        }
    }
}
