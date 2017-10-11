using System;
using System.Collections.Generic;
using System.Text;

namespace Rh.Entities.RhEntrevista
{
    public class Empresa
    {
        /// <summary>
        /// Construtor default.
        /// </summary>
        public Empresa()
        {
            ListaTecnologia = new HashSet<Tecnologia>();
            ListaVaga = new HashSet<Vaga>();
        }

        public int EmpresaId { get; set; }

        public string Nome { get; set; }

        public IEnumerable<Tecnologia> ListaTecnologia { get; set; }

        public IEnumerable<Vaga> ListaVaga { get; set; }
    }
}
