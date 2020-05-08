using api_clientes.application.Abstracts;
using api_clientes.application.DTO.Models;
using api_clientes.cross.cutting.Abstracts;
using api_clientes.grpc.services.cliente.Protos;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace api_clientes.application.Concrets
{
    public class ClienteApplicationService : IClienteApplicationService
    {

        #region Variáveis
        private readonly IMapperCliente _mapperCliente;
        private readonly ClienteService.ClienteServiceClient _serviceGrpcCliente;
        #endregion

        #region Construtor
        public ClienteApplicationService(IMapperCliente mapperCliente, ClienteService.ClienteServiceClient serviceGrpcCliente)
        {
            this._mapperCliente = mapperCliente;
            this._serviceGrpcCliente = serviceGrpcCliente;
        }
        #endregion

        #region Listar
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClienteDTO> Listar()
        {
            var clientes = _serviceGrpcCliente.Listar(new EmptyCliente { });

            return _mapperCliente.ListProtoToListDTO(clientes.Items);
        }
        #endregion

        #region Obter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClienteDTO Obter(int? id)
        {
            var cliente = _serviceGrpcCliente.Obter(new RequestCliente { Id = id.Value });

            return _mapperCliente.ProtoToDTO(cliente);
        }
        #endregion

        #region Inserir
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clienteDTO"></param>
        public void Inserir(ClienteDTO clienteDTO)
        {
            var proto = _mapperCliente.DTOToProto(clienteDTO);

            var cliente = new ClientePost
            {
                IdEndereco = proto.IdEndereco,
                Nome = proto.Nome,
                Sobrenome = proto.Sobrenome,
                Cpf = proto.Cpf,
                Sexo = proto.Sexo.ToString()
            };

            _serviceGrpcCliente.Inserir(cliente);
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="clienteDTO"></param>
        public void Alterar(ClienteDTO clienteDTO)
        {
            var proto = _mapperCliente.DTOToProto(clienteDTO);

            var cliente = new ClientePut
            {   
                Id = clienteDTO.Id.Value,
                IdEndereco = proto.IdEndereco,
                Nome = proto.Nome,
                Sobrenome = proto.Sobrenome,
                Cpf = proto.Cpf,
                Sexo = proto.Sexo.ToString()
            };

            _serviceGrpcCliente.Alterar(cliente);
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(int? id)
        {
            _serviceGrpcCliente.Excluir(new RequestCliente { Id = id.Value });
        }
        #endregion
    }
}
