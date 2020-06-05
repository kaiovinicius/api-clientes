using api_customer.application.DTO.Models;
using System.Collections.Generic;

namespace api_customer.application.Abstracts
{
    public interface ICustomerApplicationService
    {
        IEnumerable<CustomerDTO> List();

        CustomerDTO Get(int? id);

        void Insert(CustomerDTO customerDTO);

        void Update(CustomerDTO customerDTO);

        void Delete(int? id);
    }
}
