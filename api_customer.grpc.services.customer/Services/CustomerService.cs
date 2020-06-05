using api_customer.domain.core.Abstracts.Repositories.DbCustomer;
using api_customer.grpc.services.customer.Protos;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using static api_customer.grpc.services.customer.Protos.CustomerService;

namespace api_customer.grpc.services.customer.Services
{
    public class CustomerService : CustomerServiceBase
    {
        #region Constructor
        private readonly ICustomerRepository _repositoryCustomer;

        public CustomerService(ICustomerRepository repositoryCustomer)
        {
            this._repositoryCustomer = repositoryCustomer;
        }
        #endregion

        #region List
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<CustomersGet> List(Empty request, ServerCallContext context)
        {
            CustomersGet protos = new CustomersGet();

            var customers = _repositoryCustomer.List().ToList();

            foreach (var customer in customers)
            {
                var proto = new CustomerGet
                {
                    Id = customer.Id.Value,
                    IdAddress = customer.IdAddress.Value,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Cpf = customer.Cpf,
                    Genre = customer.Genre.ToString()
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
        public override Task<CustomerGet> Get(Request request, ServerCallContext context)
        {
            var customer = _repositoryCustomer.Get(request.Id);

            return Task.FromResult(new CustomerGet
            {
                Id = customer.Id.Value,
                IdAddress = customer.IdAddress.Value,
                Name = customer.Name,
                Surname = customer.Surname,
                Cpf = customer.Cpf,
                Genre = customer.Genre.ToString()
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
        public override Task<Empty> Insert(CustomerPost request, ServerCallContext context)
        {
            var customer = new domain.Entities.Customer
            {
                IdAddress = request.IdAddress,
                Name = request.Name,
                Surname = request.Surname,
                Cpf = request.Cpf,
                Genre = request.Genre.ToCharArray()[0]
            };

            _repositoryCustomer.Insert(customer);

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
        public override Task<Empty> Update(CustomerPut request, ServerCallContext context)
        {
            var customer = new domain.Entities.Customer
            {
                Id = request.Id,
                IdAddress = request.IdAddress,
                Name = request.Name,
                Surname = request.Surname,
                Cpf = request.Cpf,
                Genre = request.Genre.ToCharArray()[0]
            };

            if (_repositoryCustomer.Get(customer.Id) == null)
            {
                throw new ApplicationException("Customer not found.");
            }

            _repositoryCustomer.Update(customer);

            return Task.FromResult(new Empty());
        }
        #endregion

        #region Excluir
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Empty> Delete(Request request, ServerCallContext context)
        {
            if (_repositoryCustomer.Get(request.Id) == null)
            {
                throw new ApplicationException("Customer not found.");
            }

            _repositoryCustomer.Delete(request.Id);

            return Task.FromResult(new Empty());
        }
        #endregion
    }
}