using api_clientes.domain.core.Abstracts.Repositories.DbEnderecos;
using api_clientes.domain.core.Abstracts.Services;
using api_clientes.domain.Entities;
using api_clientes.domain.Services;
using System;

namespace api_clientes.services.Services
{
    public class EnderecoService : ServiceBaseEnderecos<Endereco>, IEnderecoService
    {
        #region Construtor
        private readonly IEnderecoRepository _repositoryEndereco;

        public EnderecoService(IEnderecoRepository repositoryEndereco) : base(repositoryEndereco)
        {
            this._repositoryEndereco = repositoryEndereco;
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="endereco"></param>
        public override void Alterar(Endereco endereco)
        {
            if (_repositoryEndereco.Obter(endereco.Id) == null)
            {
                throw new ApplicationException("Endereco não encontrado.");
            }

            _repositoryEndereco.Alterar(endereco);
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        public override void Excluir(int? id)
        {
            if (_repositoryEndereco.Obter(id) == null)
            {
                throw new ApplicationException("Endereco não encontrado.");
            }

            _repositoryEndereco.Excluir(id);
        }
        #endregion
    }
}
