using api_clientes.domain.core.Abstracts.Repositories.DbEnderecos;
using api_clientes.grpc.services.endereco.Protos;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using static api_clientes.grpc.services.endereco.Protos.EnderecoService;

namespace api_clientes.grpc.services.endereco.Services
{
    public class EnderecoService : EnderecoServiceBase
    {
        #region Construtor
        private readonly IEnderecoRepository _repositoryEndereco;

        public EnderecoService(IEnderecoRepository repositoryEndereco)
        {
            this._repositoryEndereco = repositoryEndereco;
        }
        #endregion

        #region Listar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EnderecosGet> Listar(Empty request, ServerCallContext context)
        {
            EnderecosGet protos = new EnderecosGet();

            var enderecos = _repositoryEndereco.Listar().ToList();

            foreach (var endereco in enderecos)
            {
                var proto = new Protos.EnderecoGet
                {
                    Id = endereco.Id.Value,
                    IdCliente = endereco.IdCliente.Value,
                    Cep = endereco.Cep,
                    Logradouro = endereco.Logradouro,
                    Cidade = endereco.Cidade,
                    Bairro = endereco.Bairro,
                    Estado = endereco.Estado
                };

                protos.Items.Add(proto);
            }

            return Task.FromResult(protos);
        }
        #endregion

        #region Obter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EnderecoGet> Obter(Request request, ServerCallContext context)
        {
            var endereco = _repositoryEndereco.Obter(request.Id);

            return Task.FromResult(new Protos.EnderecoGet
            {
                Id = endereco.Id.Value,
                IdCliente = endereco.IdCliente.Value,
                Cep = endereco.Cep,
                Logradouro = endereco.Logradouro,
                Cidade = endereco.Cidade,
                Bairro = endereco.Bairro,
                Estado = endereco.Estado
            });
        }
        #endregion

        #region Inserir
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Empty> Inserir(EnderecoPost request, ServerCallContext context)
        {
            var endereco = new domain.Entities.Endereco
            {   
                IdCliente = request.IdCliente,
                Cep = request.Cep,
                Logradouro = request.Logradouro,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                Estado = request.Estado,
            };

            _repositoryEndereco.Inserir(endereco);

            return Task.FromResult(new Empty());
        }
        #endregion

        #region Alterar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Empty> Alterar(EnderecoPut request, ServerCallContext context)
        {
            var endereco = new domain.Entities.Endereco
            {
                Id = request.Id,
                IdCliente = request.IdCliente,
                Cep = request.Cep,
                Logradouro = request.Logradouro,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                Estado = request.Estado,
            };

            if (_repositoryEndereco.Obter(endereco.Id) == null)
            {
                throw new ApplicationException("Endereco não encontrado.");
            }

            _repositoryEndereco.Alterar(endereco);

            return Task.FromResult(new Empty());
        }
        #endregion

        #region Excluir
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Empty> Excluir(Request request, ServerCallContext context)
        {
            if (_repositoryEndereco.Obter(request.Id) == null)
            {
                throw new ApplicationException("Endereco não encontrado.");
            }

            _repositoryEndereco.Excluir(request.Id);

            return Task.FromResult(new Empty());
        }
        #endregion
    }
}