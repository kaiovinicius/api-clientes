using api_customer.domain.core.Abstracts.Repositories.DbAddress;
using api_customer.grpc.services.address.Protos;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using static api_customer.grpc.services.address.Protos.AddressService;

namespace api_customer.grpc.services.address.Services
{
    public class AddressService : AddressServiceBase
    {
        #region Constructor
        private readonly IAdressRepository _repositoryAddress;

        public AddressService(IAdressRepository repositoryAddress)
        {
            this._repositoryAddress = repositoryAddress;
        }
        #endregion

        #region List
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<AddressesGet> List(Empty request, ServerCallContext context)
        {
            AddressesGet protos = new AddressesGet();

            var addresses = _repositoryAddress.List().ToList();

            foreach (var address in addresses)
            {
                var proto = new AddressGet
                {
                    Id = address.Id.Value,
                    ZipCode = address.ZipCode,
                    PublicArea = address.PublicArea,
                    City = address.City,
                    Neighborhood = address.Neighborhood,
                    State = address.State
                };

                protos.Items.Add(proto);
            }

            return Task.FromResult(protos);
        }
        #endregion

        #region Get
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<AddressGet> Get(Request request, ServerCallContext context)
        {
            var address = _repositoryAddress.Get(request.Id);

            return Task.FromResult(new AddressGet
            {
                Id = address.Id.Value,
                ZipCode = address.ZipCode,
                PublicArea = address.PublicArea,
                City = address.City,
                Neighborhood = address.Neighborhood,
                State = address.State
            });
        }
        #endregion

        #region Insert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Empty> Insert(AddresPost request, ServerCallContext context)
        {
            var address = new domain.Entities.Address
            {
                ZipCode = request.ZipCode,
                PublicArea = request.PublicArea,
                Neighborhood = request.Neighborhood,
                City = request.City,
                State = request.State,
            };

            _repositoryAddress.Insert(address);

            return Task.FromResult(new Empty());
        }
        #endregion

        #region Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Empty> Update(AddressPut request, ServerCallContext context)
        {
            var address = new domain.Entities.Address
            {
                Id = request.Id,
                ZipCode = request.ZipCode,
                PublicArea = request.PublicArea,
                Neighborhood = request.Neighborhood,
                City = request.City,
                State = request.State,
            };

            if (_repositoryAddress.Get(address.Id) == null)
            {
                throw new ApplicationException("Address not found.");
            }

            _repositoryAddress.Update(address);

            return Task.FromResult(new Empty());
        }
        #endregion

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Empty> Delete(Request request, ServerCallContext context)
        {
            if (_repositoryAddress.Get(request.Id) == null)
            {
                throw new ApplicationException("Address not found.");
            }

            _repositoryAddress.Delete(request.Id);

            return Task.FromResult(new Empty());
        }
        #endregion
    }
}