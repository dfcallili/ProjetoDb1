namespace Rh.Entities.RhEntrevista
{
    public class EntrevistaTecnologia
    {
        public int EntrevistaTecnologiaId { get; set; }
        public int EntrevistaId { get; set; }
        public int VagaTecnologiaId { get; set; }

        public virtual Entrevista Entrevista { get; set; }
        public virtual VagaTecnologia VagaTecnologia { get; set; }
    }
}
