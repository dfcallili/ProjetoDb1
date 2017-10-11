using System.Collections;
using System.Collections.Generic;

namespace Rh.Entities.RhEntrevista
{
    public class Candidato
    {
        public Candidato()
        {
            ListaEntrevista = new HashSet<Entrevista>();
        }

        public int CandidatoId { get; set; }
        public string Nome { get; set; }

        public ICollection<Entrevista> ListaEntrevista { get; set; }
    }
}
