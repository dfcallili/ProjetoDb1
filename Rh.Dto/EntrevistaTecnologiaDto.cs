using Rh.Entities.RhEntrevista;

namespace Rh.Dto
{
    public class EntrevistaTecnologiaDto
    {
        public int EntrevistaTecnologiaId { get; set; }
        public int EntrevistaId { get; set; }
        public int VagaTecnologiaId { get; set; }
        public string TecnologiaNome { get; set; }

        public static explicit operator EntrevistaTecnologiaDto(EntrevistaTecnologia model)
        {
            if (model == null)
                return null;

            EntrevistaTecnologiaDto dto = new EntrevistaTecnologiaDto();
            dto.EntrevistaTecnologiaId = model.EntrevistaTecnologiaId;
            dto.EntrevistaId = model.EntrevistaId;
            dto.VagaTecnologiaId = model.VagaTecnologiaId;
            dto.TecnologiaNome =  model.VagaTecnologia?.Tecnologia?.Nome;


            return dto;
        }
    }
}
