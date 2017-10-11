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
    public class VagaController : Controller
    {
        private IVagaService vagaService;
        private readonly ILogger _logger;

        /// <summary>
        /// Construtor Default
        /// </summary>
        /// <param name="_vagaService">Interface do Serviço a ser utilizado.</param>
        /// <param name="logger">Interface do Serviço de logger a ser utilizado.</param>
        public VagaController(IVagaService _vagaService, ILogger<CandidatoController> logger)
        {
            vagaService = _vagaService;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet, Produces("application/json")]
        public IActionResult Get()
        {
            try
            {
                List<VagaDto> lista = vagaService.Get();
                if (lista.Any())
                    return Ok(lista);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Houve um erro ao buscar as Vagas.");
                return StatusCode(500);
            }
        }

        // GET api/values/5
        [HttpGet("{id}"), Produces("application/json")]
        public IActionResult Get(int id)
        {
            try
            {
                VagaDto dto = vagaService.Get(id);
                if (dto != null)
                    return Ok(dto);
                else
                    return NotFound(id);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao buscar uma Vaga ID {0}.", id));
                return StatusCode(500);
            }
        }

        // POST api/values
        [HttpPost, Produces("application/json")]
        public IActionResult Post([FromBody]VagaDto dto)
        {
            try
            {
                VagaDto novaVaga = vagaService.Add(dto);

                if (novaVaga != null)
                    return Ok(novaVaga);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao cadastrar uma Vaga {0}.", dto));
                return StatusCode(500);
            }
        }

        // PUT api/values/5
        [HttpPut, Produces("application/json")]
        public IActionResult Put([FromBody]VagaDto dto)
        {
            try
            {
                VagaDto VagaAtualizada = vagaService.Update(dto);

                if (VagaAtualizada != null)
                    return Ok(VagaAtualizada);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao atualizar uma Vaga {0}.", dto));
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

                if (vagaService.Get(id) == null)
                    return NotFound();

                vagaService.Delete(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao remover uma Vaga. ID {0}.", id));
                return StatusCode(500);
            }
        }
    }
}
