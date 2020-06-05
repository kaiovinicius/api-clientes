using api_customer.application.DTO.Models;
using System.Collections.Generic;

namespace api_customer.application.Abstracts
{
    public interface IContactApplicationService
    {
        IEnumerable<ContactDTO> List();

        ContactDTO Get(int? id);

        void Insert(ContactDTO contactDTO);

        void Update(ContactDTO contactDTO);

        void Delete(int? id);
    }
}
