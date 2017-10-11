using Rh.Dto;
using System.Collections.Generic;

namespace Rh.Service.Contracts
{
    public interface ICandidatoService
    {
        /// <summary>
        /// Método responsável por retornar todos os Candidatos Cadastrados.
        /// </summary>
        /// <returns>Lista de candidatos.</returns>
        List<CandidatoDto> Get();

        /// <summary>
        /// Método responsável por retornar um Candidato a partir do seu identificador.
        /// </summary>
        /// <param name="candidatoId">Identificador do Candidado.</param>
        /// <returns>Candidato buscado.</returns>
        CandidatoDto Get(int candidatoId);

        /// <summary>
        /// Método responsável por adicionar um novo candidato.
        /// </summary>
        /// <param name="dtoCandidato">dados do candidato a ser inserido.</param>
        /// <returns>Candidato criado.</returns>
        CandidatoDto Add(CandidatoDto dtoCandidato);

        /// <summary>
        /// Método responsável por atualizar os dados de um candidato.
        /// </summary>
        /// <param name="dtoCandidatoAtualizar">Dados do candidato a ser atualizado.</param>
        /// <returns>Candidato atualizado.</returns>
        CandidatoDto Update(CandidatoDto dtoCandidatoAtualizar);

        /// <summary>
        /// Método responsável por remover um candidato.
        /// </summary>
        /// <param name="candidatoId">identifador do candidato a ser removido.</param>
        void Delete(int candidatoId);
    }
}
