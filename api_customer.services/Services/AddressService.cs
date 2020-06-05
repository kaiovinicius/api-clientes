using api_customer.domain.core.Abstracts.Repositories.DbAddress;
using api_customer.domain.core.Abstracts.Services;
using api_customer.domain.Entities;
using api_customer.domain.Services;
using System;

namespace api_customer.services.Services
{
    public class AddressService : AddressServiceBase<Address>, IAddressService
    {
        #region Constructor
        private readonly IAdressRepository _repositoryAddress;

        public AddressService(IAdressRepository repositoryAddress) : base(repositoryAddress)
        {
            this._repositoryAddress = repositoryAddress;
        }
        #endregion

        public override void Update(Address address)
        {
            if (_repositoryAddress.Get(address.Id) == null)
            {
                throw new ApplicationException("Address not found.");
            }

            _repositoryAddress.Update(address);
        }

        public override void Delete(int? id)
        {
            if (_repositoryAddress.Get(id) == null)
            {
                throw new ApplicationException("Address not found.");
            }

            _repositoryAddress.Delete(id);
        }
    }
}