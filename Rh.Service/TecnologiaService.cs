using Rh.Data.Contracts;
using Rh.Dto;
using Rh.Entities.RhEntrevista;
using Rh.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rh.Service
{
    public class TecnologiaService : ITecnologiaService
    {
        private IRhUow rhUow { get; set; }
        public TecnologiaService(IRhUow _rhUow)
        {
            rhUow = _rhUow;
        }

        public List<TecnologiaDto> Get()
        {
            return rhUow.Tecnologia.GetAll().ToList().Select(el => (TecnologiaDto)el).ToList();
        }

        public TecnologiaDto Get(int tecnologiaId)
        {
            return (TecnologiaDto)rhUow.Tecnologia.GetById(tecnologiaId);
        }

        public TecnologiaDto Add(TecnologiaDto tecnologiaDto)
        {
            if (tecnologiaDto == null)
                throw new Exception("Informe os dados da Tecnologia a ser adicionada.");

            if (string.IsNullOrWhiteSpace(tecnologiaDto.Nome))
                throw new Exception("Não foi informado o nome da Tecnlogia.");

            VerificaNomeUnico(tecnologiaDto);

            Tecnologia novaTecnlogia = new Tecnologia();
            novaTecnlogia.Nome = tecnologiaDto.Nome;
            rhUow.Tecnologia.Add(novaTecnlogia);
            rhUow.Commit();

            return (TecnologiaDto)novaTecnlogia;
        }

        public TecnologiaDto Update(TecnologiaDto tecnolodiaDtoAtualizar)
        {
            if (tecnolodiaDtoAtualizar == null)
                throw new Exception("Informe os dados da Tecnologia a ser atualizada.");

            if (tecnolodiaDtoAtualizar.TecnologiaId == 0)
                throw new Exception("Informe o Identificador da Tecnologia.");

            if (string.IsNullOrWhiteSpace(tecnolodiaDtoAtualizar.Nome))
                throw new Exception("Informe o Nome da Tecnologia a ser atualizada.");

            VerificaNomeUnico(tecnolodiaDtoAtualizar);

            Tecnologia tecnologiaAtualizar = rhUow.Tecnologia.GetById(tecnolodiaDtoAtualizar.TecnologiaId);

            tecnologiaAtualizar.Nome = tecnolodiaDtoAtualizar.Nome;

            rhUow.Tecnologia.Update(tecnologiaAtualizar);
            rhUow.Commit();
            return (TecnologiaDto)tecnologiaAtualizar;
        }

        public void Delete(int tecnologiaId)
        {
            Tecnologia tecnologiaRemover = rhUow.Tecnologia.GetById(tecnologiaId);

            if (tecnologiaRemover.ListaVagaTecnologia.Any())
                throw new Exception("Esta Tecnologia já foi disponibilizada em uma Vaga. Por este motivo não é possível removê-la.");

            if (tecnologiaRemover.ListaEntrevistaTecnologia.Any())
                throw new Exception("Esta Tecnologia já foi disponibilizada em uma Entrevista. Por este motivo não é possível removê-la.");

            rhUow.Tecnologia.Delete(tecnologiaRemover);
            rhUow.Commit();
        }

        #region Métodos Privados

        /// <summary>
        /// Método responsável por verificar se já existe uma Tecnologia cadastrada com este Nome.
        /// </summary>
        /// <param name="dtoTecnologia">Dados da tecnologia a ser verificado.</param>
        private void VerificaNomeUnico(TecnologiaDto dtoTecnologia)
        {
            bool tecnlogiaDiferente = rhUow.Tecnologia.GetAll()
                .Any(t => t.Nome == dtoTecnologia.Nome
                && t.TecnologiaId != dtoTecnologia.TecnologiaId);

            if (tecnlogiaDiferente)
                throw new Exception("Já existe uma Tecnologia com este Nome. Favor digite um nome Diferente.");
        }
        #endregion
    }
}
