using api_customer.application.DTO.Models;
using System.Collections.Generic;

namespace api_customer.application.Abstracts
{
    public interface IAddressApplicationService
    {
        IEnumerable<AddressDTO> List();

        AddressDTO Get(int? id);

        void Insert(AddressDTO addressDTO);

        void Update(AddressDTO addressDTO);

        void Delete(int? id);
    }
}
