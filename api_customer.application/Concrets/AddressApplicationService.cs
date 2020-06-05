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
        private readonly AddressService.AddressServiceClient _serviceGrpcAddress;
        #endregion

        #region Constructor
        public AddressApplicationService(AddressService.AddressServiceClient serviceGrpcAddress, AddressIMapper mapperAddres)
        {
            this._mapperAddress = mapperAddres;
            this._serviceGrpcAddress = serviceGrpcAddress;
        }
        #endregion

        public IEnumerable<AddressDTO> List()
        {
            var addresses = _serviceGrpcAddress.List(new Empty { }).Items;

            return _mapperAddress.ListProtoToListDTO(addresses);
        }

        public AddressDTO Get(int? id)
        {
            var address = _serviceGrpcAddress.Get(new Request { Id = id.Value });

            return _mapperAddress.ProtoToDTO(address);
        }

        public void Insert(AddressDTO addressDTO)
        {
            var proto = _mapperAddress.DTOToProto(addressDTO);

            var address = new AddresPost
            {
                ZipCode = addressDTO.ZipCode,
                PublicArea = addressDTO.PublicArea,
                Neighborhood = addressDTO.Neighborhood,
                City = addressDTO.City,
                State = addressDTO.State,
            };

            _serviceGrpcAddress.Insert(address);
        }

        public void Update(AddressDTO addressDTO)
        {
            var proto = _mapperAddress.DTOToEntity(addressDTO);

            var address = new AddressPut
            {   
                Id = addressDTO.Id.Value,
                ZipCode = addressDTO.ZipCode,
                PublicArea = addressDTO.PublicArea,
                Neighborhood = addressDTO.Neighborhood,
                City = addressDTO.City,
                State = addressDTO.State,
            };

            _serviceGrpcAddress.Update(address);
        }

        public void Delete(int? id)
        {
            _serviceGrpcAddress.Delete(new Request { Id = id.Value});
        }
    }
}
