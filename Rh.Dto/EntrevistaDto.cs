using Rh.Entities.RhEntrevista;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rh.Dto
{
    public class EntrevistaDto
    {
        public EntrevistaDto()
        {
            ListaEntrevistaTecnologia = new List<EntrevistaTecnologiaDto>();
        }

        public int EntrevistaId { get; set; }
        public int VagaId { get; set; }
        public string VagaDescricao { get; set; }
        public int CandidatoId { get; set; }
        public string CandidatoNome { get; set; }
        public DateTime DataEntrevista { get; set; }

        public List<EntrevistaTecnologiaDto> ListaEntrevistaTecnologia { get; set; }

        public static explicit operator EntrevistaDto (Entrevista model)
        {
            if (model == null)
                return null;

            EntrevistaDto dto = new EntrevistaDto();
            dto.EntrevistaId = model.EntrevistaId;
            dto.VagaId = model.VagaId;
            dto.VagaDescricao = model.Vaga != null ? model.Vaga.Descricao : string.Empty;
            dto.CandidatoId = model.CandidatoId;
            dto.CandidatoNome = model.Candidato != null ? model.Candidato.Nome : string.Empty;
            dto.DataEntrevista = model.DataEntrevista;
            dto.ListaEntrevistaTecnologia = model.ListaEntrevistaTecnologia.ToList().Select(t => (EntrevistaTecnologiaDto)t).ToList();

            return dto;
        }
    }
}
