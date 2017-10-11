using Rh.Dto;
using System.Collections.Generic;

namespace Rh.Service.Contracts
{
    public interface ITecnologiaService
    {
        /// <summary>
        /// Método responsável por retornar todos as Tecnologias Cadastradas.
        /// </summary>
        /// <returns>Lista de Tecnologias.</returns>
        List<TecnologiaDto> Get();

        /// <summary>
        /// Método responsável por retornar uma Tecnologia a partir do seu identificador.
        /// </summary>
        /// <param name="tecnologiaId">Identificador da Tecnologia.</param>
        /// <returns>Tecnologia buscada.</returns>
        TecnologiaDto Get(int tecnologiaId);

        /// <summary>
        /// Método responsável por adicionar uma nova Tecnologia.
        /// </summary>
        /// <param name="dtoTecnologia">Dados da Tecnologia a ser inserida.</param>
        /// <returns>Tecnologia criada.</returns>
        TecnologiaDto Add(TecnologiaDto dtoTecnologia);

        /// <summary>
        /// Método responsável por atualizar os dados de uma Tecnologia.
        /// </summary>
        /// <param name="dtoTecnologiaAtualizar">Dados da Tecnologia a ser atualizada.</param>
        /// <returns>Tecnologia atualizada.</returns>
        TecnologiaDto Update(TecnologiaDto dtoTecnologiaAtualizar);

        /// <summary>
        /// Método responsável por remover uma tecnologia.
        /// </summary>
        /// <param name="tecnologiaId">identifador da Tecnologia a ser removida.</param>
        void Delete(int tecnologiaId);
    }
}
