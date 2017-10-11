using Microsoft.EntityFrameworkCore;
using Rh.Data.Contracts;
using Rh.Entities.RhEntrevista;
using System;
using System.Threading.Tasks;

namespace Rh.Data.Context.Ef
{
    public class RhUow : IRhUow
    {
        private DbContext Context { get; set; }

        private IRepositoryProvider RepositoryProvider { get; set; }


        public RhUow(IRepositoryProvider repositoryProvider)
        {
            Context = new RhDbContext();

            repositoryProvider.DbContext = Context;

            RepositoryProvider = repositoryProvider;
        }


        //Repositorys
        public IRepository<Candidato> Candidato { get { return GetStandardRepo<Candidato>(); } }
        public IRepository<Empresa> Empresa { get { return GetStandardRepo<Empresa>(); } }
        public IRepository<Entrevista> Entrevista { get { return GetStandardRepo<Entrevista>(); } }
        public IRepository<EntrevistaTecnologia> EntrevistaTecnologia { get { return GetStandardRepo<EntrevistaTecnologia>(); } }
        public IRepository<Tecnologia> Tecnologia { get { return GetStandardRepo<Tecnologia>(); } }
        public IRepository<Vaga> Vaga { get { return GetStandardRepo<Vaga>(); } }
        public IRepository<VagaTecnologia> VagaTecnologia { get { return GetStandardRepo<VagaTecnologia>(); } }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        #region Disposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                    Context.Dispose();
            }
        }

        #endregion
    }
}
