using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rh.Entities.RhEntrevista;

namespace Rh.Entities.Mapping.RhEntrevista
{
    public class VagaMap : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            // Primary Key
            builder.HasKey(t => t.VagaId);

            // Properties
            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            builder.ToTable("Vaga", "RhEntrevista");
            builder.Property(t => t.VagaId).HasColumnName("VagaId");
            builder.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
