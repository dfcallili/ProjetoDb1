using Rh.Entities.RhEntrevista;

namespace Rh.Dto
{
    public class CandidatoDto
    {
        public int CandidatoId { get; set; }
        public string Nome { get; set; }

        public static explicit operator CandidatoDto(Candidato model)
        {
            if (model == null)
                return null;

            CandidatoDto dto = new CandidatoDto();
            dto.CandidatoId = model.CandidatoId;
            dto.Nome = model.Nome;

            return dto;
        }
    }

    public class CandidatoNotaDto : CandidatoDto
    {
        public int Total { get; set; }

        public static explicit operator CandidatoNotaDto(Candidato model)
        {
            if (model == null)
                return null;

            CandidatoNotaDto dto = new CandidatoNotaDto();
            dto.CandidatoId = model.CandidatoId;
            dto.Nome = model.Nome;

            return dto;
        }
    }
}
