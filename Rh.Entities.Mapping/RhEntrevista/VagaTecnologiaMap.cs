using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rh.Entities.RhEntrevista;
using System;

namespace Rh.Entities.Mapping.RhEntrevista
{
    public class VagaTecnologiaMap : IEntityTypeConfiguration<VagaTecnologia>
    {
        public void Configure(EntityTypeBuilder<VagaTecnologia> builder)
        {
            // Primary Key
            builder.HasKey(t => t.VagaTecnologiaId);

            // Properties
            builder.Property(t => t.Peso).IsRequired(false);

            // Table & Column Mappings
            builder.ToTable("VagaTecnologia", "RhEntrevista");
            builder.Property(t => t.VagaTecnologiaId).HasColumnName("VagaTecnologiaId");
            builder.Property(t => t.VagaId).HasColumnName("VagaId");
            builder.Property(t => t.TecnologiaId).HasColumnName("TecnologiaId");
            builder.Property(t => t.Peso).HasColumnName("Peso");

            // Relationships
            builder.HasOne(t => t.Vaga)
                .WithMany(t => t.ListaVagaTecnologia)
                .HasForeignKey(t => t.VagaId);

            builder.HasOne(t => t.Tecnologia)
                .WithMany(t => t.ListaVagaTecnologia)
                .HasForeignKey(t => t.TecnologiaId);
        }
    }
}
