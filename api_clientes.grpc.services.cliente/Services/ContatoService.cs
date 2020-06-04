using api_customer.domain.core.Abstracts.Repositories.DbClientes;
using api_customer.grpc.services.cliente.Protos;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using static api_customer.grpc.services.cliente.Protos.ContatoService;

namespace api_customer.grpc.services.cliente.Services
{
    public class ContatoService : ContatoServiceBase
    {
        #region Construtor
        private readonly IContactRepository _repositoryContato;

        public ContatoService(IContactRepository repositoryContato)
        {
            this._repositoryContato = repositoryContato;
        }
        #endregion

        #region Listar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<ContatosGet> Listar(EmptyContato request, ServerCallContext context)
        {
            ContatosGet protos = new ContatosGet();

            var contatos = _repositoryContato.List().ToList();

            foreach (var contato in contatos)
            {
                var proto = new ContatoGet
                {
                    Id = contato.Id.Value,
                    IdCliente = contato.IdCustomer,
                    Ddd = contato.Ddd,
                    Numero = contato.Number,
                    Email = contato.Email
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
        public override Task<ContatoGet> Obter(RequestContato request, ServerCallContext context)
        {
            var contato = _repositoryContato.Get(request.Id);

            return Task.FromResult(new ContatoGet
            {
                Id = contato.Id.Value,
                IdCliente = contato.IdCustomer,
                Ddd = contato.Ddd,
                Numero = contato.Number,
                Email = contato.Email
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
        public override Task<EmptyContato> Inserir(ContatoPost request, ServerCallContext context)
        {
            var contato = new domain.Entities.Contact
            {
                IdCustomer = request.IdCliente,
                Ddd = request.Ddd,
                Number = request.Numero,
                Email = request.Email
            };

            _repositoryContato.Insert(contato);

            return Task.FromResult(new EmptyContato());
        }
        #endregion

        #region Alterar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptyContato> Alterar(ContatoPut request, ServerCallContext context)
        {
            var contato = new domain.Entities.Contact
            {
                Id = request.Id,
                IdCustomer = request.IdCliente,
                Ddd = request.Ddd,
                Number = request.Numero,
                Email = request.Email
            };

            if (_repositoryContato.Get(contato.Id) == null)
            {
                throw new ApplicationException("Contato não encontrado.");
            }

            _repositoryContato.Update(contato);

            return Task.FromResult(new EmptyContato());
        }
        #endregion

        #region Excluir
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<EmptyContato> Excluir(RequestContato request, ServerCallContext context)
        {
            if (_repositoryContato.Get(request.Id) == null)
            {
                throw new ApplicationException("Contato não encontrado.");
            }

            _repositoryContato.Delete(request.Id);

            return Task.FromResult(new EmptyContato());
        }
        #endregion
    }
}
