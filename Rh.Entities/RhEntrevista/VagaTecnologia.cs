using System.Collections.Generic;

namespace Rh.Entities.RhEntrevista
{
    public class VagaTecnologia
    {
        public VagaTecnologia()
        {
            ListaEntrevistaTecnologia = new HashSet<EntrevistaTecnologia>();
        }

        public int VagaTecnologiaId { get; set; }
        public int VagaId { get; set; }
        public int TecnologiaId { get; set; }
        public int? Peso { get; set; }

        public virtual Vaga  Vaga { get; set; }
        public virtual Tecnologia Tecnologia { get; set; }

        public ICollection<EntrevistaTecnologia> ListaEntrevistaTecnologia { get; set; }
    }
}
