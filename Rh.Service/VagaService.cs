using Rh.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Rh.Dto;
using Rh.Data.Contracts;
using System.Linq;
using Rh.Entities.RhEntrevista;
using Rh.Service.Util;

namespace Rh.Service
{
    public class VagaService : IVagaService
    {
        private IRhUow rhUow { get; set; }
        public VagaService(IRhUow _rhUow)
        {
            rhUow = _rhUow;
        }

        public List<VagaDto> Get()
        {
            return rhUow.Vaga.GetAll(t=> t.ListaEntrevista).ToList().Select(el => (VagaDto)el).ToList();
        }

        public VagaDto Get(int vagaId)
        {
            Vaga vaga = rhUow.Vaga.GetById(vagaId);
            vaga.ListaVagaTecnologia = rhUow.VagaTecnologia.GetAll().Where(t => t.VagaId == vagaId).ToList();
            vaga.ListaEntrevista = rhUow.Entrevista.GetAll().Where(t => t.VagaId == vagaId).ToList();

            VagaDto dto = (VagaDto)vaga;
            return dto;
        }

        public List<VagaTecnologiaDto> GetTecnologiaByVagaId(int vagaId)
        {
            List<VagaTecnologia> vagaTecnologia = rhUow.VagaTecnologia.GetAll().Where(t => t.VagaId == vagaId).ToList();
            foreach (var i in vagaTecnologia)
                i.Tecnologia = rhUow.Tecnologia.GetById(i.TecnologiaId);

            return vagaTecnologia.Select(t => (VagaTecnologiaDto)t).ToList();

        }

        public VagaDto Add(VagaDto dtoVaga)
        {
            if (dtoVaga == null)
                throw new Exception("Informe os dados da Vaga a ser adicionada.");

            if (string.IsNullOrWhiteSpace(dtoVaga.Descricao))
                throw new Exception("Não foi informado o nome da Vaga.");

            VerificaNomeUnico(dtoVaga);

            if (!dtoVaga.ListaVagaTecnologia.Any())
                throw new Exception("Não foi informado nenhuma Tecnologia para esta Vaga.");

            Vaga novaVaga = new Vaga();
            novaVaga.Descricao = dtoVaga.Descricao;
            VincularTecnologia(dtoVaga, novaVaga);

            rhUow.Vaga.Add(novaVaga);
            rhUow.Commit();
            return (VagaDto)novaVaga;
        }

        public VagaDto Update(VagaDto dtoVagaAtualizar)
        {
            if (dtoVagaAtualizar == null)
                throw new ServiceException("Informe os dados da Vaga a ser atualizada.");

            if (dtoVagaAtualizar.VagaId == 0)
                throw new ServiceException("Informe o Identificador da Vaga.");

            if (string.IsNullOrWhiteSpace(dtoVagaAtualizar.Descricao))
                throw new ServiceException("Informe o Nome da Vaga a ser atualizada.");

            VerificaNomeUnico(dtoVagaAtualizar);

            Vaga vagaAtualizar = rhUow.Vaga.GetById(dtoVagaAtualizar.VagaId);
            VerificaVinculos(vagaAtualizar);

            List<VagaTecnologia> tecnologiasVaga = vagaAtualizar.ListaVagaTecnologia.ToList();

            foreach (var tec in tecnologiasVaga)
                vagaAtualizar.ListaVagaTecnologia.Remove(tec);


            vagaAtualizar.Descricao = dtoVagaAtualizar.Descricao;
            VincularTecnologia(dtoVagaAtualizar, vagaAtualizar);

            rhUow.Vaga.Update(vagaAtualizar);
            rhUow.Commit();
            return (VagaDto)vagaAtualizar;
        }

        public void Delete(int vagaId)
        {
            Vaga vagaRemover = rhUow.Vaga.GetById(vagaId);

            VerificaVinculos(vagaRemover);

            rhUow.Vaga.Delete(vagaRemover);
            rhUow.Commit();
        }


        public List<CandidatoNotaDto> CalcularClassificacao(VagaDto dtoVaga)
        {
            if (dtoVaga == null)
                throw new ServiceException("Informe os dados da Vaga a ser atualizada.");

            if (dtoVaga.VagaId == 0)
                throw new ServiceException("Informe o Identificador da Vaga.");

            List<Entrevista> listEntrevista = rhUow.Entrevista.GetAll(t=> t.Candidato, t=> t.ListaEntrevistaTecnologia).Where(t => t.VagaId == dtoVaga.VagaId).ToList();
            List<CandidatoNotaDto> listaCandidato = new List<CandidatoNotaDto>();
            foreach(var i in listEntrevista)
            {
                var candidatoAtual = (CandidatoNotaDto)i.Candidato;
                foreach (var entrevistaTecnologia in i.ListaEntrevistaTecnologia)
                {
                    var vagaTecnologia = rhUow.VagaTecnologia.GetById(entrevistaTecnologia.VagaTecnologiaId);
                    var vagaPesoAtual = dtoVaga.ListaVagaTecnologia.FirstOrDefault(t => t.TecnologiaId == vagaTecnologia.TecnologiaId);

                    if (entrevistaTecnologia != null)
                        candidatoAtual.Total += vagaPesoAtual.Peso.Value;

                }
                listaCandidato.Add(candidatoAtual);
            }

            return listaCandidato.OrderByDescending(t => t.Total).ToList();
        }


        #region Métodos Privados

        /// <summary>
        /// Método responsável por verificar se já existe uma Vaga cadastrada com esta Descrição.
        /// </summary>
        /// <param name="dtoVaga">Dados da vaga a ser verificado.</param>
        private void VerificaNomeUnico(VagaDto dtoVaga)
        {
            bool vagaDiferente = rhUow.Vaga.GetAll()
                .Any(t => t.Descricao == dtoVaga.Descricao
                && t.VagaId != dtoVaga.VagaId);

            if (vagaDiferente)
                throw new Exception("Já existe uma Vaga com esta Descrição. Favor digite um nome Diferente.");
        }

        /// <summary>
        /// Método responsável por vincular as Tecnologias Informadas a Vaga a ser criada.
        /// </summary>
        /// <param name="dtoVaga">Dto da Vaga que está sendo criada.</param>
        /// <param name="novaVaga">Nova vaga criada para vinculá-la as tecnologias.</param>
        private void VincularTecnologia(VagaDto dtoVaga, Vaga novaVaga)
        {
            foreach (var vagaTecnologiaAtual in dtoVaga.ListaVagaTecnologia)
            {
                VagaTecnologia vagaTecnologia = new VagaTecnologia();
                vagaTecnologia.TecnologiaId = vagaTecnologiaAtual.TecnologiaId;

                novaVaga.ListaVagaTecnologia.Add(vagaTecnologia);
            }
        }

        /// <summary>
        /// Verifica se uma vaga pode ser Editada ou Removida
        /// </summary>
        /// <param name="vagaAnalisar"></param>
        private void VerificaVinculos(Vaga vagaAnalisar)
        {
            if (vagaAnalisar.ListaVagaTecnologia.Any())
                throw new ServiceException("Esta Vaga possui vinculos com Tecnologias");

            if (vagaAnalisar.ListaEntrevista.Any())
                throw new ServiceException("Esta Vaga já foi utilizada em uma Entrevista");
        }

        #endregion
    }
}
