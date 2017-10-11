using System;
using System.Collections.Generic;
using System.Text;

namespace Rh.Entities.RhEntrevista
{
    public class Entrevista
    {
        public Entrevista()
        {
            ListaEntrevistaTecnologia = new HashSet<EntrevistaTecnologia>();
        }
        public int EntrevistaId { get; set; }
        public int VagaId { get; set; }
        public int CandidatoId { get; set; }
        public DateTime DataEntrevista { get; set; }

        public virtual Vaga Vaga { get; set; }
        public virtual Candidato Candidato { get; set; }
        public ICollection<EntrevistaTecnologia> ListaEntrevistaTecnologia { get; set; }
    }
}
