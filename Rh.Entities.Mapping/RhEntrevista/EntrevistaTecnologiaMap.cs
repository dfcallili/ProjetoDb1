using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rh.Entities.RhEntrevista;

namespace Rh.Entities.Mapping.RhEntrevista
{
    public class EntrevistaTecnologiaMap : IEntityTypeConfiguration<EntrevistaTecnologia>
    {
        public void Configure(EntityTypeBuilder<EntrevistaTecnologia> builder)
        {
            // Primary Key
            builder.HasKey(t => t.EntrevistaTecnologiaId);


            // Table & Column Mappings
            builder.ToTable("EntrevistaTecnologia", "RhEntrevista");
            builder.Property(t => t.EntrevistaTecnologiaId).HasColumnName("EntrevistaTecnologiaId");
            builder.Property(t => t.EntrevistaId).HasColumnName("EntrevistaId");
            builder.Property(t => t.EntrevistaTecnologiaId).HasColumnName("EntrevistaTecnologiaId");

            // Relationships
            builder.HasOne(t => t.VagaTecnologia)
                .WithMany(t => t.ListaEntrevistaTecnologia)
                .HasForeignKey(t => t.VagaTecnologiaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Entrevista)
                .WithMany(t => t.ListaEntrevistaTecnologia)
                .HasForeignKey(t => t.EntrevistaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
