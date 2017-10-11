using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rh.Dto;
using Rh.Service.Contracts;
using Rh.Service.Util;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rh.Application.Controllers
{
    [Route("api/[controller]")]
    public class EntrevistaController : Controller
    {
        private IEntrevistaService entrevistaService;
        private readonly ILogger _logger;

        /// <summary>
        /// Construtor Default
        /// </summary>
        /// <param name="_entrevistaService">Interface do Serviço a ser utilizado.</param>
        /// <param name="logger">Interface do Serviço de logger a ser utilizado.</param>
        public EntrevistaController(IEntrevistaService _entrevistaService, ILogger<EntrevistaController> logger)
        {
            entrevistaService = _entrevistaService;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet, Produces("application/json")]
        public IActionResult Get()
        {
            try
            {
                List<EntrevistaDto> lista = entrevistaService.Get();
                if (lista.Any())
                    return Ok(lista);
                else
                    return NotFound("Nenhum registro encontrado.");
            }
            catch(ServiceException sex)
            {
                return NotFound(sex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Houve um erro ao buscar as Entrevistas.");
                return StatusCode(500, "Houve um erro ao buscar as Entrevistas.");
            }
        }

        // GET api/values/5
        [HttpGet("{id}"), Produces("application/json")]
        public IActionResult Get(int id)
        {
            try
            {
                EntrevistaDto dto = entrevistaService.Get(id);
                if (dto != null)
                    return Ok(dto);
                else
                    return NotFound(id);
            }
            catch (ServiceException sex)
            {
                return NotFound(sex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao buscar uma Entrevista ID {0}.", id));
                return StatusCode(500);
            }
        }

        // POST api/values
        [HttpPost, Produces("application/json")]
        public IActionResult Post([FromBody]EntrevistaDto dto)
        {
            try
            {
                EntrevistaDto novaEntrevista = entrevistaService.Add(dto);

                if (novaEntrevista != null)
                    return Ok(novaEntrevista);
                else
                    return NotFound("Entrevista não foi processada com Sucesso.");
            }
            catch (ServiceException sex)
            {
                return NotFound(sex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, string.Format("Houve um erro ao cadastrar uma Entrevista {0}.", dto));
                return StatusCode(500);
            }
        }
    }
}
