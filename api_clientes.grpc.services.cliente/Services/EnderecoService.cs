using api_clientes.domain.core.Abstracts.Repositories.DbEnderecos;
using api_clientes.grpc.services.cliente.Protos;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using static api_clientes.grpc.services.cliente.Protos.EnderecoService;

namespace api_clientes.grpc.services.cliente.Services
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
        public override Task<Enderecos> Listar(Protos.Empty request, ServerCallContext context)
        {
            Enderecos protos = new Enderecos();

            var enderecos = _repositoryEndereco.Listar().ToList();

            foreach (var endereco in enderecos)
            {
                var proto = new Protos.Endereco
                {
                    Id = endereco.Id.Value,
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
        public override Task<Protos.Endereco> Obter(Request request, ServerCallContext context)
        {
            var endereco = _repositoryEndereco.Obter(request.Id);

            return Task.FromResult(new Protos.Endereco
            {
                Id = endereco.Id.Value,
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
        public override Task<Empty> Inserir(Protos.Endereco request, ServerCallContext context)
        {
            var endereco = new domain.Entities.Endereco
            {
                Id = request.Id,
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
        public override Task<Empty> Alterar(Protos.Endereco request, ServerCallContext context)
        {
            var endereco = new domain.Entities.Endereco
            {
                Id = request.Id,
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