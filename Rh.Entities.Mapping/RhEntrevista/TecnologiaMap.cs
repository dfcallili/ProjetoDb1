using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rh.Entities.RhEntrevista;

namespace Rh.Entities.Mapping.RhEntrevista
{
    public class TecnologiaMap : IEntityTypeConfiguration<Tecnologia>
    {
        public void Configure(EntityTypeBuilder<Tecnologia> builder)
        {
            // Primary Key
            builder.HasKey(t => t.TecnologiaId);

            // Properties
            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            builder.ToTable("Tecnologia", "RhEntrevista");
            builder.Property(t => t.TecnologiaId).HasColumnName("TecnologiaId");
            builder.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
