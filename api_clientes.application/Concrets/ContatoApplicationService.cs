using api_clientes.application.Abstracts;
using api_clientes.application.DTO.Models;
using api_clientes.cross.cutting.Abstracts;
using api_clientes.domain.core.Abstracts.Services;
using api_clientes.grpc.services.cliente.Protos;
using System.Collections.Generic;

namespace api_clientes.application.Concrets
{
    public class ContatoApplicationService : IContatoApplicationService
    {
        #region Variáveis
        private readonly IMapperContato _mapperContato;
        private readonly ContatoService.ContatoServiceClient _serviceGrpcContato;
        #endregion

        #region Construtor
        public ContatoApplicationService(IContatoService serviceContato, ContatoService.ContatoServiceClient serviceGrpcContato, IMapperContato mapperContato)
        {
            this._serviceGrpcContato = serviceGrpcContato;
            this._mapperContato = mapperContato;
        }
        #endregion

        #region Listar
        /// <summary>
        /// Listar
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContatoDTO> Listar()
        {
            var contatos = _serviceGrpcContato.Listar(new EmptyContato { }).Items;

            return _mapperContato.ListProtoToListDTO(contatos);
        }
        #endregion

        #region Obter
        /// <summary>
        /// Obter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContatoDTO Obter(int? id)
        {
            var contato = _serviceGrpcContato.Obter(new RequestContato { Id = id.Value});

            return _mapperContato.ProtoToDTO(contato);
        }
        #endregion

        #region Inserir
        /// <summary>
        /// Inserir
        /// </summary>
        /// <param name="contatoDTO"></param>
        public void Inserir(ContatoDTO contatoDTO)
        {
            var proto = _mapperContato.DTOToProto(contatoDTO);

            var contato = new ContatoPost
            {
                IdCliente = proto.IdCliente,
                Ddd = proto.Ddd,
                Numero = proto.Numero,
                Email = proto.Email
            };

            _serviceGrpcContato.Inserir(contato);
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="contatoDTO"></param>
        public void Alterar(ContatoDTO contatoDTO)
        {
            var proto = _mapperContato.DTOToProto(contatoDTO);

            var contato = new ContatoPut
            {
                Id = contatoDTO.Id.Value,
                IdCliente = proto.IdCliente,
                Ddd = proto.Ddd,
                Numero = proto.Numero,
                Email = proto.Email
            };

            _serviceGrpcContato.Alterar(contato);
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(int? id)
        {
            _serviceGrpcContato.Excluir(new RequestContato { Id = id.Value });
        }
        #endregion
    }
}
