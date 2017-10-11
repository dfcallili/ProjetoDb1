using Rh.Entities.RhEntrevista;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rh.Dto
{
    public class TecnologiaDto
    {
        public int TecnologiaId { get; set; }
        public string Nome { get; set; }

        public static explicit operator TecnologiaDto(Tecnologia model)
        {
            if (model == null)
                return null;

            TecnologiaDto dto = new TecnologiaDto();
            dto.TecnologiaId = model.TecnologiaId;
            dto.Nome = model.Nome;

            return dto;

        }
    }
}
