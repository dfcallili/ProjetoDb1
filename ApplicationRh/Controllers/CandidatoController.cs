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
    public class CandidatoController : Controller
    {
        private ICandidatoService candidatoService;
        private readonly ILogger _logger;

        /// <summary>
        /// Construtor Default
        /// </summary>
        /// <param name="_candidatoService">Interface do Serviço a ser utilizado.</param>
        /// <param name="logger">Interface do Serviço de logger a ser utilizado.</param>
        public CandidatoController(ICandidatoService _candidatoService, ILogger<CandidatoController> logger)
        {
            candidatoService = _candidatoService;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet, Produces("application/json")]
        public IActionResult Get()
        {
            try
            {
                List<CandidatoDto> lista = candidatoService.Get();
                if (lista.Any())
                    return Ok(lista);
                else
                    return NotFound();
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex, "Houve um erro ao buscar os Candidatos.");
                return StatusCode(500);
            }
        }

        // GET api/values/5
        [HttpGet("{id}"), Produces("application/json")]
        public IActionResult Get(int id)
        {
            try
            {
                CandidatoDto dto = candidatoService.Get(id);
                if (dto != null)
                    return Ok(dto);
                else
                    return NotFound(id);
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao buscar um Candidato ID {0}.",id));
                return StatusCode(500);
            }
        }

        // POST api/values
        [HttpPost, Produces("application/json")]
        public IActionResult Post([FromBody]CandidatoDto dto)
        {
            try
            {
                CandidatoDto novoCandidato =  candidatoService.Add(dto);

                if (novoCandidato != null)
                    return Ok(novoCandidato);
                else
                    return NotFound();
            }
            catch( Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao cadastrar um Candidato {0}.", dto));
                return StatusCode(500);
            }
        }

        // PUT api/values/5
        [HttpPut, Produces("application/json")]
        public IActionResult Put([FromBody]CandidatoDto dto)
        {
            try
            {
                CandidatoDto candidatoAtualizado =  candidatoService.Update(dto);

                if (candidatoAtualizado != null)
                    return Ok(candidatoAtualizado);
                else
                    return NotFound();
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao atualizar um Candidato {0}.", dto));
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

                if (candidatoService.Get(id) == null)
                    return NotFound();

                candidatoService.Delete(id);
                return Ok(id);
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao remover um Candidato ID {0}.", id));
                return StatusCode(500);
            }
        }
    }
}
