using api_customer.application.Abstracts;
using api_customer.application.DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace api_customer.getway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        #region Variáveis
        private readonly ICustomerApplicationService applicationServiceCustomer;
        #endregion

        #region Construtor
        public CustomersController(ICustomerApplicationService applicationServiceCustomer)
        {
            this.applicationServiceCustomer = applicationServiceCustomer;
        }
        #endregion

        #region List
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CustomerDTO> List()
        {
            var customers = applicationServiceCustomer.List();

            return new List<CustomerDTO>(customers);
        }
        #endregion

        #region Get
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public CustomerDTO Get(int id)
        {
            var customer = applicationServiceCustomer.Get(id);

            return customer;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Inserir
        /// </summary>
        /// <param name="clienteDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert([FromBody] CustomerDTO clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            applicationServiceCustomer.Insert(clienteDTO);

            return Ok("Customer successfully registered!");
        }
        #endregion

        #region Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Update([FromBody] CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            applicationServiceCustomer.Update(customerDTO);

            return Ok("Customer Changed successfully!");
        }
        #endregion

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            applicationServiceCustomer.Delete(id);

            return Ok("Customer Deleted successfully!");
        }
        #endregion
    }
}