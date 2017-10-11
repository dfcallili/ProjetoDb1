using Rh.Entities.RhEntrevista;
using System.Collections.Generic;
using System.Linq;

namespace Rh.Dto
{
    public class VagaDto
    {
        public VagaDto()
        {
            ListaVagaTecnologia = new List<VagaTecnologiaDto>();
        }

        public int VagaId { get; set; }

        public string Descricao { get; set; }

        public List<VagaTecnologiaDto> ListaVagaTecnologia { get; set; }

        public bool VagaJaEntrevistada { get; set; }

        public static explicit operator VagaDto(Vaga model)
        {
            if (model == null)
                return null;

            VagaDto dto = new VagaDto();

            dto.VagaId = model.VagaId;
            dto.Descricao = model.Descricao;
            dto.ListaVagaTecnologia = model.ListaVagaTecnologia.Any() ?
                model.ListaVagaTecnologia.ToList().Select(t => (VagaTecnologiaDto)t).ToList()
                : new List<VagaTecnologiaDto>();

            dto.VagaJaEntrevistada = model.ListaEntrevista.Any();
            return dto;
        }
    }
}
