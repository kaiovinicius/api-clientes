using api_clientes.domain.core.Abstracts.Repositories.DbClientes;
using api_clientes.domain.core.Abstracts.Services;
using api_clientes.domain.Entities;
using System;

namespace api_clientes.domain.Services
{
    public class ClienteService : ServiceBaseClientes<Cliente>, IClienteService
    {
        #region Construtor
        private readonly IClienteRepository _repositoryCliente;
        private readonly IContatoRepository _repositoryContato;

        public ClienteService(IClienteRepository repositoryCliente,
                              IContatoRepository repositoryContato) : base(repositoryCliente)
        {
            this._repositoryCliente = repositoryCliente;
            this._repositoryContato = repositoryContato;
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="cliente"></param>
        public override void Alterar(Cliente cliente)
        {
            if (_repositoryCliente.Obter(cliente.Id) == null)
            {
                throw new ApplicationException("Contato não encontrado.");
            }

            _repositoryCliente.Alterar(cliente);
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        public override void Excluir(int? id)
        {
            var contato = _repositoryContato.ObterPorIdCliente(id);

            if (contato != null)
            {
                _repositoryContato.Excluir(contato.Id);
            }

            _repositoryCliente.Excluir(id);
        }
        #endregion
    }
}