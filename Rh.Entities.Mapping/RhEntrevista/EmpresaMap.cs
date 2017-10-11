using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rh.Entities.RhEntrevista;

namespace Rh.Entities.Mapping.RhEntrevista
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            // Primary Key
            builder.HasKey(t => t.EmpresaId);

            // Properties
            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            builder.ToTable("Empresa", "RhEntrevista");
            builder.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            builder.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
