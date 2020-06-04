using api_customer.application.Abstracts;
using api_customer.application.DTO.Models;
using api_customer.cross.cutting.Abstracts;
using api_customer.grpc.services.address.Protos;
using System.Collections.Generic;

namespace api_customer.application.Concrets
{
    public class AddressApplicationService : IAddressApplicationService
    {

        #region Variables
        private readonly AddressIMapper _mapperAddress;
        private readonly EnderecoService.EnderecoServiceClient _serviceGrpcAddress;

        #endregion

        #region Constructor
        public AddressApplicationService(EnderecoService.EnderecoServiceClient serviceGrpcAddress, AddressIMapper mapperAddres)
        {
            this._mapperAddress = mapperAddres;
            this._serviceGrpcAddress = serviceGrpcAddress;
        }
        #endregion

        #region List
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AddressDTO> List()
        {
            var addresses = _serviceGrpcAddress.Listar(new Empty { }).Items;

            return _mapperAddress.ListProtoToListDTO(addresses);
        }
        #endregion

        #region List
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AddressDTO Get(int? id)
        {
            var address = _serviceGrpcAddress.Obter(new Request { Id = id.Value });

            return _mapperAddress.ProtoToDTO(address);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressDTO"></param>
        public void Insert(AddressDTO addressDTO)
        {
            var proto = _mapperAddress.DTOToProto(addressDTO);

            var address = new EnderecoPost
            {
                Cep = addressDTO.ZipCode,
                Logradouro = addressDTO.PublicArea,
                Bairro = addressDTO.PublicArea,
                Cidade = addressDTO.City,
                Estado = addressDTO.State,
            };

            _serviceGrpcAddress.Inserir(address);
        }
        #endregion

        #region Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressDTO"></param>
        public void Update(AddressDTO addressDTO)
        {
            var proto = _mapperAddress.DTOToEntity(addressDTO);

            var address = new EnderecoPut
            {   
                Id = addressDTO.Id.Value,
                Cep = addressDTO.ZipCode,
                Logradouro = addressDTO.PublicArea,
                Bairro = addressDTO.PublicArea,
                Cidade = addressDTO.City,
                Estado = addressDTO.State,
            };

            _serviceGrpcAddress.Alterar(address);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int? id)
        {
            _serviceGrpcAddress.Excluir(new Request { Id = id.Value});
        }
        #endregion
    }
}
