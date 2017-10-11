using System;
using System.Collections.Generic;
using System.Text;

namespace Rh.Entities.RhEntrevista
{
    public class Tecnologia
    {
        public Tecnologia()
        {
            ListaVagaTecnologia = new HashSet<VagaTecnologia>();
            ListaEntrevistaTecnologia = new HashSet<EntrevistaTecnologia>();
        }

        public int TecnologiaId { get; set; }
        public string Nome { get; set; }
        public ICollection<VagaTecnologia> ListaVagaTecnologia { get; set; }
        public ICollection<EntrevistaTecnologia> ListaEntrevistaTecnologia { get; set; }
    }
}
