using api_clientes.domain.core.Abstracts.Repositories.DbClientes;
using api_clientes.grpc.services.cliente.Protos;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using static api_clientes.grpc.services.cliente.Protos.ClienteService;

namespace api_clientes.grpc.services.cliente.Services
{
    public class ClienteService : ClienteServiceBase
    {
        #region Construtor
        private readonly IClienteRepository _repositoryCliente;

        public ClienteService(IClienteRepository repositoryCliente)
        {
            this._repositoryCliente = repositoryCliente;
        }
        #endregion

        #region Listar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<ClientesGet> Listar(EmptyCliente request, ServerCallContext context)
        {
            ClientesGet protos = new ClientesGet();

            var clientes = _repositoryCliente.Listar().ToList();

            foreach (var cliente in clientes)
            {
                var proto = new ClienteGet
                {
                    Id = cliente.Id.Value,
                    IdEndereco = cliente.IdEndereco.Value,
                    Nome = cliente.Nome,
                    Sobrenome = cliente.Sobrenome,
                    Cpf = cliente.Cpf,
                    Sexo = cliente.Sexo.ToString()
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
        public override Task<ClienteGet> Obter(RequestCliente request, ServerCallContext context)
        {
            var cliente = _repositoryCliente.Obter(request.Id);

            return Task.FromResult(new Protos.ClienteGet
            {
                Id = cliente.Id.Value,
                IdEndereco = cliente.IdEndereco.Value,
                Nome = cliente.Nome,
                Sobrenome = cliente.Sobrenome,
                Cpf = cliente.Cpf,
                Sexo = cliente.Sexo.ToString()
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
        public override Task<EmptyCliente> Inserir(ClientePost request, ServerCallContext context)
        {
            var cliente = new domain.Entities.Cliente
            {
                IdEndereco = request.IdEndereco,
                Nome = request.Nome,
                Sobrenome = request.Sobrenome,
                Cpf = request.Cpf,
                Sexo = request.Sexo.ToCharArray()[0]
            };

            _repositoryCliente.Inserir(cliente);

            return Task.FromResult(new EmptyCliente());
        }
        #endregion

        #region Alterar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptyCliente> Alterar(ClientePut request, ServerCallContext context)
        {
            var cliente = new domain.Entities.Cliente
            {
                Id = request.Id,
                IdEndereco = request.IdEndereco,
                Nome = request.Nome,
                Sobrenome = request.Sobrenome,
                Cpf = request.Cpf,
                Sexo = request.Sexo.ToCharArray()[0]
            };

            if (_repositoryCliente.Obter(cliente.Id) == null)
            {
                throw new ApplicationException("Cliente não encontrado.");
            }

            _repositoryCliente.Alterar(cliente);

            return Task.FromResult(new EmptyCliente());
        }
        #endregion

        #region Excluir
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptyCliente> Excluir(RequestCliente request, ServerCallContext context)
        {
            if (_repositoryCliente.Obter(request.Id) == null)
            {
                throw new ApplicationException("Cliente não encontrado.");
            }

            _repositoryCliente.Excluir(request.Id);

            return Task.FromResult(new EmptyCliente());
        }
        #endregion
    }
}