using api_clientes.application.Abstracts;
using api_clientes.application.DTO.Models;
using api_clientes.cross.cutting.Abstracts;
using api_clientes.grpc.services.endereco.Protos;
using System.Collections.Generic;

namespace api_clientes.application.Concrets
{
    public class EnderecoApplicationService : IEnderecoApplicationService
    {

        #region Variáveis
        private readonly IMapperEndereco _mapperEndereco;
        private readonly EnderecoService.EnderecoServiceClient _serviceGrpcEndereco;

        #endregion

        #region Construtor
        public EnderecoApplicationService(EnderecoService.EnderecoServiceClient serviceGrpcEndereco, IMapperEndereco mapperEndereco)
        {
            this._mapperEndereco = mapperEndereco;
            this._serviceGrpcEndereco = serviceGrpcEndereco;
        }
        #endregion

        #region Listar
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EnderecoDTO> Listar()
        {
            var enderecos = _serviceGrpcEndereco.Listar(new Empty { }).Items;

            return _mapperEndereco.ListProtoToListDTO(enderecos);
        }
        #endregion

        #region Obter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EnderecoDTO Obter(int? id)
        {
            var endereco = _serviceGrpcEndereco.Obter(new Request { Id = id.Value });

            return _mapperEndereco.ProtoToDTO(endereco);
        }
        #endregion

        #region Inserir
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enderecoDTO"></param>
        public void Inserir(EnderecoDTO enderecoDTO)
        {
            var proto = _mapperEndereco.DTOToProto(enderecoDTO);

            var endereco = new EnderecoPost
            {
                Cep = enderecoDTO.Cep,
                Logradouro = enderecoDTO.Logradouro,
                Bairro = enderecoDTO.Logradouro,
                Cidade = enderecoDTO.Cidade,
                Estado = enderecoDTO.Estado,
            };

            _serviceGrpcEndereco.Inserir(endereco);
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="enderecoDTO"></param>
        public void Alterar(EnderecoDTO enderecoDTO)
        {
            var proto = _mapperEndereco.DTOToEntity(enderecoDTO);

            var endereco = new EnderecoPut
            {   
                Id = enderecoDTO.Id.Value,
                Cep = enderecoDTO.Cep,
                Logradouro = enderecoDTO.Logradouro,
                Bairro = enderecoDTO.Logradouro,
                Cidade = enderecoDTO.Cidade,
                Estado = enderecoDTO.Estado,
            };

            _serviceGrpcEndereco.Alterar(endereco);
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(int? id)
        {
            _serviceGrpcEndereco.Excluir(new Request { Id = id.Value});
        }
        #endregion
    }
}
