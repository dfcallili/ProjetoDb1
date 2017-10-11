using Rh.Dto;
using System.Collections.Generic;

namespace Rh.Service.Contracts
{
    public interface IVagaService
    {
        /// <summary>
        /// Método responsável por retornar todos as Vagas Cadastradas.
        /// </summary>
        /// <returns>Lista de Vagas.</returns>
        List<VagaDto> Get();

        /// <summary>
        /// Método responsável por retornar uma Vaga a partir do seu identificador.
        /// </summary>
        /// <param name="vagaId">Identificador da Vaga.</param>
        /// <returns>Vaga buscada.</returns>
        VagaDto Get(int vagaId);

        /// <summary>
        /// Método responsável por adicionar uma nova Vaga.
        /// </summary>
        /// <param name="dtoVaga">Dados da vaga a ser inserida.</param>
        /// <returns>Vaga criada.</returns>
        VagaDto Add(VagaDto dtoVaga);

        /// <summary>
        /// Método responsável por atualizar os dados de uma Vaga.
        /// </summary>
        /// <param name="dtoVagaAtualizar">Dados da Vaga a ser atualizada.</param>
        /// <returns>Vaga atualizada.</returns>
        VagaDto Update(VagaDto dtoVagaAtualizar);

        /// <summary>
        /// Método responsável por remover uma Vaga.
        /// </summary>
        /// <param name="vagaId">identifador da Vaga a ser removida.</param>
        void Delete(int vagaId);

        /// <summary>
        /// Método responsável por retornar todas as Tecnologias de Uma Vaga.
        /// </summary>
        /// <param name="vagaId">Identicador da vaga</param>
        /// <returns>Lista de Tecnologias da Vaga.</returns>
        List<VagaTecnologiaDto> GetTecnologiaByVagaId(int vagaId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtoVaga"></param>
        /// <returns></returns>
        List<CandidatoNotaDto> CalcularClassificacao(VagaDto dtoVaga);
    }
}
