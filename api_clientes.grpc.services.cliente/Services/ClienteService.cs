using api_customer.domain.core.Abstracts.Repositories.DbClientes;
using api_customer.grpc.services.cliente.Protos;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using static api_customer.grpc.services.cliente.Protos.ClienteService;

namespace api_customer.grpc.services.cliente.Services
{
    public class ClienteService : ClienteServiceBase
    {
        #region Construtor
        private readonly ICustomerRepository _repositoryCliente;

        public ClienteService(ICustomerRepository repositoryCliente)
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

            var clientes = _repositoryCliente.List().ToList();

            foreach (var cliente in clientes)
            {
                var proto = new ClienteGet
                {
                    Id = cliente.Id.Value,
                    IdEndereco = cliente.IdAddress.Value,
                    Nome = cliente.Name,
                    Sobrenome = cliente.Surname,
                    Cpf = cliente.Cpf,
                    Sexo = cliente.Genre.ToString()
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
            var cliente = _repositoryCliente.Get(request.Id);

            return Task.FromResult(new Protos.ClienteGet
            {
                Id = cliente.Id.Value,
                IdEndereco = cliente.IdAddress.Value,
                Nome = cliente.Name,
                Sobrenome = cliente.Surname,
                Cpf = cliente.Cpf,
                Sexo = cliente.Genre.ToString()
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
            var cliente = new domain.Entities.Customer
            {
                IdAddress = request.IdEndereco,
                Name = request.Nome,
                Surname = request.Sobrenome,
                Cpf = request.Cpf,
                Genre = request.Sexo.ToCharArray()[0]
            };

            _repositoryCliente.Insert(cliente);

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
            var cliente = new domain.Entities.Customer
            {
                Id = request.Id,
                IdAddress = request.IdEndereco,
                Name = request.Nome,
                Surname = request.Sobrenome,
                Cpf = request.Cpf,
                Genre = request.Sexo.ToCharArray()[0]
            };

            if (_repositoryCliente.Get(cliente.Id) == null)
            {
                throw new ApplicationException("Cliente não encontrado.");
            }

            _repositoryCliente.Update(cliente);

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
            if (_repositoryCliente.Get(request.Id) == null)
            {
                throw new ApplicationException("Cliente não encontrado.");
            }

            _repositoryCliente.Delete(request.Id);

            return Task.FromResult(new EmptyCliente());
        }
        #endregion
    }
}