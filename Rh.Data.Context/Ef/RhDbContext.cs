using Microsoft.EntityFrameworkCore;
using Rh.Entities.Mapping.RhEntrevista;
using Rh.Entities.RhEntrevista;

namespace Rh.Data.Context.Ef
{
    public partial class RhDbContext : DbContext
    {
        public RhDbContext(DbContextOptions<RhDbContext> options) : base(options)
        {
            
        }
        public RhDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, 
                //you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 
                //for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(local);Database=RhEntrevistaDb;Trusted_Connection=True;");
            }
        }


        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Entrevista> Entrevista { get; set; }
        public DbSet<EntrevistaTecnologia> EntrevistaTecnologia { get; set; }
        public DbSet<Tecnologia> Tecnologia { get; set; }
        public DbSet<Vaga> Vaga { get; set; }
        public DbSet<VagaTecnologia> VagaTecnologia { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidatoMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new EntrevistaMap());
            modelBuilder.ApplyConfiguration(new EntrevistaTecnologiaMap());
            modelBuilder.ApplyConfiguration(new TecnologiaMap());
            modelBuilder.ApplyConfiguration(new VagaMap());
            modelBuilder.ApplyConfiguration(new VagaTecnologiaMap());

        }
    }
}
