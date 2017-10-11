using Rh.Data.Contracts;
using Rh.Dto;
using Rh.Entities.RhEntrevista;
using Rh.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rh.Service
{
    public class CandidatoService : ICandidatoService
    {
        private IRhUow rhUow { get; set; }
        public CandidatoService(IRhUow _rhUow)
        {
            rhUow = _rhUow;
        }

        public List<CandidatoDto> Get()
        {
            return rhUow.Candidato.GetAll().ToList().Select(el => (CandidatoDto)el).ToList();
        }

        public CandidatoDto Get(int candidatoId)
        {
           return (CandidatoDto)rhUow.Candidato.GetById(candidatoId);
        }

        public CandidatoDto Add(CandidatoDto candidatoDto)
        {
            if (candidatoDto == null)
                throw new Exception("Informe os dados do Candidto a ser adicionado.");

            if (string.IsNullOrWhiteSpace(candidatoDto.Nome))
                throw new Exception("Não foi informado o nome do Candidato.");

            VerificaCandidatoUnico(candidatoDto);

            Candidato novoCandidato = new Candidato();
            novoCandidato.Nome = candidatoDto.Nome;
            rhUow.Candidato.Add(novoCandidato);
            rhUow.Commit();

            return (CandidatoDto)novoCandidato;
        }

        public CandidatoDto Update(CandidatoDto candidatoDtoAtualizar)
        {
            if (candidatoDtoAtualizar == null)
                throw new Exception("Informe os dados do Candidto a ser atualizado.");

            if (candidatoDtoAtualizar.CandidatoId == 0)
                throw new Exception("Informe o Identificador do Candito.");

            if (string.IsNullOrWhiteSpace(candidatoDtoAtualizar.Nome))
                throw new Exception("Informe o Nome do Candidato a ser atualizado.");

            VerificaCandidatoUnico(candidatoDtoAtualizar);

            Candidato candidatoAtualizar = rhUow.Candidato.GetById(candidatoDtoAtualizar.CandidatoId);

            candidatoAtualizar.Nome = candidatoDtoAtualizar.Nome;

            rhUow.Candidato.Update(candidatoAtualizar);
            rhUow.Commit();

            return (CandidatoDto)candidatoAtualizar;
        }

        public void Delete(int candidatoId)
        {
            Candidato candidatoRemover = rhUow.Candidato.GetById(candidatoId);

            if (candidatoRemover.ListaEntrevista.Any())
                throw new Exception("Este candidato já participou de uma Entrevista. Por este motivo não é possível removê-lo.");


            rhUow.Candidato.Delete(candidatoRemover);
            rhUow.Commit();
        }

        #region Métodos Privados

        /// <summary>
        /// Método responsável por verificar se já existe um Candidato com o mesmo Nome já cadastrado.
        /// </summary>
        /// <param name="candidatoDto">Dados do candidato a ser analisado.</param>
        private void VerificaCandidatoUnico(CandidatoDto candidatoDto)
        {
            bool candidatoDiferente = rhUow.Candidato.GetAll()
                .Any(t => t.Nome == candidatoDto.Nome
                && t.CandidatoId != candidatoDto.CandidatoId);

            if (candidatoDiferente)
                throw new Exception("");
        }
        #endregion
    }
}
