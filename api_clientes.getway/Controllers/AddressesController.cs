using api_customer.application.Abstracts;
using api_customer.application.DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api_customer.getway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        #region Constructor
        private readonly IAddressApplicationService applicationServiceAddress;

        public AddressesController(IAddressApplicationService applicationServiceAddress)
        {
            this.applicationServiceAddress = applicationServiceAddress;
        }
        #endregion

        #region List
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<AddressDTO> List()
        {
            var addresses = applicationServiceAddress.List();

            return new List<AddressDTO>(addresses);
        }
        #endregion

        #region Get
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public AddressDTO Get(int id)
        {
            var address = applicationServiceAddress.Get(id);

            return address;
        }
        #endregion

        #region Insert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert([FromBody] AddressDTO addressDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            applicationServiceAddress.Insert(addressDTO);

            return Ok("Address successfully registered!");
        }
        #endregion

        #region Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enderecoDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Update([FromBody] AddressDTO enderecoDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            applicationServiceAddress.Update(enderecoDTO);

            return Ok("Address changed successfully!");

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
            applicationServiceAddress.Delete(id);

            return Ok("Address deleted successfully!");
        }
        #endregion
    }
}