using Rh.Entities.RhEntrevista;
using System.Collections.Generic;
using System.Linq;

namespace Rh.Dto
{
    public class VagaTecnologiaDto
    {
        public int VagaTecnologiaId { get; set; }
        public int VagaId { get; set; }
        public int TecnologiaId { get; set; }
        public string TecnologiaNome { get; set; }
        public int? Peso { get; set; }

        public List<EntrevistaTecnologiaDto> ListaEntrevistaTecnologia { get; set; }


        public static explicit operator VagaTecnologiaDto(VagaTecnologia model)
        {
            if (model == null)
                return null;

            VagaTecnologiaDto dto = new VagaTecnologiaDto();
            dto.VagaTecnologiaId = model.VagaTecnologiaId;
            dto.VagaId = model.VagaId;
            dto.TecnologiaId = model.TecnologiaId;
            dto.TecnologiaNome = model.Tecnologia != null ? model.Tecnologia.Nome : string.Empty;
            dto.Peso = model.Peso.HasValue ? model.Peso.Value : 0;
            dto.ListaEntrevistaTecnologia = model.ListaEntrevistaTecnologia.ToList().Select(t => (EntrevistaTecnologiaDto)t).ToList();

            return dto;
        }
    }
}
