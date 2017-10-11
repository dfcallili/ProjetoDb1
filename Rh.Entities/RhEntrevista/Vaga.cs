using System;
using System.Collections.Generic;
using System.Text;

namespace Rh.Entities.RhEntrevista
{
    public class Vaga
    {
        public Vaga()
        {
            ListaVagaTecnologia = new HashSet<VagaTecnologia>();
            ListaEntrevista = new HashSet<Entrevista>();
        }

        public int VagaId { get; set; }

        public string Descricao { get; set; }

        public ICollection<VagaTecnologia> ListaVagaTecnologia { get; set; }
        public ICollection<Entrevista> ListaEntrevista { get; set; }
    }
}
