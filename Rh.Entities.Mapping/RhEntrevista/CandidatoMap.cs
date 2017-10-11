using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rh.Entities.RhEntrevista;

namespace Rh.Entities.Mapping.RhEntrevista
{
    public class CandidatoMap : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            // Primary Key
            builder.HasKey(t => t.CandidatoId);

            // Properties
            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            builder.ToTable("Candidato", "RhEntrevista");
            builder.Property(t => t.CandidatoId).HasColumnName("CandidatoId");
            builder.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
