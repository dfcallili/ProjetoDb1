using Rh.Dto;
using System.Collections.Generic;

namespace Rh.Service.Contracts
{
    public interface IEntrevistaService
    {
        /// <summary>
        /// Método responsável por retornar todos as Entrevistas Cadastradas.
        /// </summary>
        /// <returns>Lista de Entrevistas.</returns>
        List<EntrevistaDto> Get();

        /// <summary>
        /// Método responsável por retornar uma Entrevista a partir do seu identificador.
        /// </summary>
        /// <param name="EntrevistaId">Identificador da Entrevista.</param>
        /// <returns>Entrevista buscada.</returns>
        EntrevistaDto Get(int EntrevistaId);

        /// <summary>
        /// Método responsável por adicionar uma nova Entrevista.
        /// </summary>
        /// <param name="dtoEntrevista">Dados da Entrevista a ser inserida.</param>
        /// <returns>Entrevista criada.</returns>
        EntrevistaDto Add(EntrevistaDto dtoEntrevista);
    }
}
