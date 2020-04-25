using api_clientes.Data_Acess.Abstracts.Repositories;
using api_clientes.domain.Abstracts;
using api_clientes.Entities;
using System;

namespace api_clientes.domain.Services
{
    public class ContatoService : ServiceBase<Contato>, IContatoService
    {
        #region Construtor
        private readonly IContatoRepository _repositoryContato;

        public ContatoService(IContatoRepository _repositoryContato) : base(_repositoryContato)
        {
            this._repositoryContato = _repositoryContato;
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="contato"></param>
        public override void Alterar(Contato contato)
        {
            if (_repositoryContato.Obter(contato.Id) == null)
            {
                throw new ApplicationException("Contato não encontrado.");
            }

            _repositoryContato.Alterar(contato);
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        public override void Excluir(int? id)
        {
            if (_repositoryContato.Obter(id) == null)
            {
                throw new ApplicationException("Contato não encontrado.");
            }

            _repositoryContato.Excluir(id);
        }
        #endregion
    }
}