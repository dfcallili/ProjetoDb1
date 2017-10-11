using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rh.Dto;
using Rh.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationRh.Controllers
{
    [Route("api/[controller]")]
    public class TecnologiaController : Controller
    {
        private ITecnologiaService tecnologiaService;
        private readonly ILogger _logger;

        /// <summary>
        /// Construtor Default
        /// </summary>
        /// <param name="_tecnologiaService">Interface do Serviço a ser utilizado.</param>
        /// <param name="logger">Interface do Serviço de logger a ser utilizado.</param>
        public TecnologiaController(ITecnologiaService _tecnologiaService, ILogger<CandidatoController> logger)
        {
            tecnologiaService = _tecnologiaService;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet, Produces("application/json")]
        public IActionResult Get()
        {
            try
            {
                List<TecnologiaDto> lista = tecnologiaService.Get();
                if (lista.Any())
                    return Ok(lista);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Houve um erro ao buscar as Tecnologias.");
                return StatusCode(500);
            }
        }

        // GET api/values/5
        [HttpGet("{id}"), Produces("application/json")]
        public IActionResult Get(int id)
        {
            try
            {
                TecnologiaDto dto = tecnologiaService.Get(id);
                if (dto != null)
                    return Ok(dto);
                else
                    return NotFound(id);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao buscar uma Tecnologia ID {0}.", id));
                return StatusCode(500);
            }
        }

        // POST api/values
        [HttpPost, Produces("application/json")]
        public IActionResult Post([FromBody]TecnologiaDto dto)
        {
            try
            {
                TecnologiaDto novaTecnologia = tecnologiaService.Add(dto);

                if (novaTecnologia != null)
                    return Ok(novaTecnologia);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao cadastrar uma Tecnologia {0}.", dto));
                return StatusCode(500);
            }
        }

        // PUT api/values/5
        [HttpPut, Produces("application/json")]
        public IActionResult Put([FromBody]TecnologiaDto dto)
        {
            try
            {
                TecnologiaDto tecnologiaAtualizada = tecnologiaService.Update(dto);

                if (tecnologiaAtualizada != null)
                    return Ok(tecnologiaAtualizada);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao atualizar uma Tecnologia {0}.", dto));
                return StatusCode(500);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}"), Produces("application/json")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                if (tecnologiaService.Get(id) == null)
                    return NotFound();

                tecnologiaService.Delete(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao remover uma Tecnologia ID {0}.", id));
                return StatusCode(500);
            }
        }
    }
}
