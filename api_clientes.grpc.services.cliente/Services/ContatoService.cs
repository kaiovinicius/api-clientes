using api_clientes.domain.core.Abstracts.Repositories.DbClientes;
using api_clientes.grpc.services.cliente.Protos;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using static api_clientes.grpc.services.cliente.Protos.ContatoService;

namespace api_clientes.grpc.services.cliente.Services
{
    public class ContatoService : ContatoServiceBase
    {
        #region Construtor
        private readonly IContatoRepository _repositoryContato;

        public ContatoService(IContatoRepository repositoryContato)
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

            var contatos = _repositoryContato.Listar().ToList();

            foreach (var contato in contatos)
            {
                var proto = new ContatoGet
                {
                    Id = contato.Id.Value,
                    IdCliente = contato.IdCliente,
                    Ddd = contato.Ddd,
                    Numero = contato.Numero,
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
            var contato = _repositoryContato.Obter(request.Id);

            return Task.FromResult(new ContatoGet
            {
                Id = contato.Id.Value,
                IdCliente = contato.IdCliente,
                Ddd = contato.Ddd,
                Numero = contato.Numero,
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
            var contato = new domain.Entities.Contato
            {
                IdCliente = request.IdCliente,
                Ddd = request.Ddd,
                Numero = request.Numero,
                Email = request.Email
            };

            _repositoryContato.Inserir(contato);

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
            var contato = new domain.Entities.Contato
            {
                Id = request.Id,
                IdCliente = request.IdCliente,
                Ddd = request.Ddd,
                Numero = request.Numero,
                Email = request.Email
            };

            if (_repositoryContato.Obter(contato.Id) == null)
            {
                throw new ApplicationException("Contato não encontrado.");
            }

            _repositoryContato.Alterar(contato);

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
            if (_repositoryContato.Obter(request.Id) == null)
            {
                throw new ApplicationException("Contato não encontrado.");
            }

            _repositoryContato.Excluir(request.Id);

            return Task.FromResult(new EmptyContato());
        }
        #endregion
    }
}
