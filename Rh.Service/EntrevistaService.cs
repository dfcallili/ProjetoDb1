using Rh.Data.Contracts;
using Rh.Dto;
using Rh.Entities.RhEntrevista;
using Rh.Service.Contracts;
using Rh.Service.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rh.Service
{
    public class EntrevistaService : IEntrevistaService
    {
        private IRhUow rhUow { get; set; }
        public EntrevistaService(IRhUow _rhUow)
        {
            rhUow = _rhUow;
        }

        public List<EntrevistaDto> Get()
        {
            return rhUow.Entrevista.GetAll(t=> t.Candidato,t => t.Vaga).ToList().Select(el => (EntrevistaDto)el).ToList();
        }

        public EntrevistaDto Get(int entrevistaId)
        {
            Entrevista entrevista = rhUow.Entrevista.GetAll(t => t.Candidato, t => t.Vaga).FirstOrDefault(t => t.EntrevistaId == entrevistaId);
            entrevista.ListaEntrevistaTecnologia = rhUow.EntrevistaTecnologia.GetAll(t=> t.VagaTecnologia.Tecnologia).Where(t => t.EntrevistaId == entrevistaId).ToList();

            EntrevistaDto dto = (EntrevistaDto)entrevista;
            return dto;
        }

        public EntrevistaDto Add(EntrevistaDto dtoEntrevista)
        {
            if (dtoEntrevista == null)
                throw new ServiceException("Informe os dados da Entrevista a ser adicionada.");

            if (dtoEntrevista.VagaId == 0)
                throw new ServiceException("Informe a Vaga para qual esta entrevista está sendo realizada.");

            if (dtoEntrevista.CandidatoId == 0)
                throw new ServiceException("Informe o Candidato que está realizando a Entrevista.");

            if (!dtoEntrevista.ListaEntrevistaTecnologia.Any())
                throw new ServiceException("Não foi informado nenhuma Tecnologia para esta Entrevista.");

            if(rhUow.Entrevista.GetAll().Any(t => t.CandidatoId == dtoEntrevista.CandidatoId && t.VagaId == dtoEntrevista.VagaId))
                throw new ServiceException("Já existe uma Entrevista para Este Candidato e Vaga selecionados.");

            Entrevista novaEntrevista = new Entrevista();
            novaEntrevista.CandidatoId = dtoEntrevista.CandidatoId;
            novaEntrevista.VagaId = dtoEntrevista.VagaId;
            novaEntrevista.DataEntrevista = DateTime.Now;

            VincularTecnologia(dtoEntrevista, novaEntrevista);

            rhUow.Entrevista.Add(novaEntrevista);
            rhUow.Commit();
            return (EntrevistaDto)novaEntrevista;
        }

        #region Métodos Privados

        /// <summary>
        /// Método responsável por vincular as Tecnologias Informadas a Entrevista a ser criada.
        /// </summary>
        /// <param name="dtoEntrevista">Dto da Entrevista que está sendo criada.</param>
        /// <param name="novaEntrevista">Nova Entrevista criada para vinculá-la as tecnologias.</param>
        private void VincularTecnologia(EntrevistaDto dtoEntrevista, Entrevista novaEntrevista)
        {
            foreach (var vagaTecnologiaAtual in dtoEntrevista.ListaEntrevistaTecnologia)
            {
                EntrevistaTecnologia entrevistaTecnologia = new EntrevistaTecnologia();
                entrevistaTecnologia.VagaTecnologiaId = vagaTecnologiaAtual.VagaTecnologiaId;

                novaEntrevista.ListaEntrevistaTecnologia.Add(entrevistaTecnologia);
            }
        }
        #endregion
    }
}
