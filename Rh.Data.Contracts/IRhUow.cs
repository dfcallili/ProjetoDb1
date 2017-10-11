using Rh.Entities.RhEntrevista;
using System;

namespace Rh.Data.Contracts
{
    public interface IRhUow : IUow, IDisposable
    {
        IRepository<Candidato> Candidato { get; }
        IRepository<Empresa> Empresa { get; }
        IRepository<Entrevista> Entrevista { get; }
        IRepository<EntrevistaTecnologia> EntrevistaTecnologia { get; }
        IRepository<Tecnologia> Tecnologia { get; }
        IRepository<Vaga> Vaga { get; }
        IRepository<VagaTecnologia> VagaTecnologia { get; }

    }
}
