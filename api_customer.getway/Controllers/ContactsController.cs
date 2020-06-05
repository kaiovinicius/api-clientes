using api_customer.application.Abstracts;
using api_customer.application.DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api_customer.getway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        #region Constructor
        private readonly IContactApplicationService applicationServiceContact;

        public ContactsController(IContactApplicationService applicationServiceContact)
        {
            this.applicationServiceContact = applicationServiceContact;
        }
        #endregion

        #region List
        /// <summary>
        /// List all Contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ContactDTO> List()
        {
            var contacts = applicationServiceContact.List();

            return new List<ContactDTO>(contacts);
        }
        #endregion

        #region Get
        /// <summary>
        /// Get a Contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ContactDTO Get(int id)
        {
            var contact = applicationServiceContact.Get(id);

            return contact;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert a Contact
        /// </summary>
        /// <param name="contactDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert([FromBody] ContactDTO contactDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            applicationServiceContact.Insert(contactDTO);

            return Ok("Contact successfully registered!");
        }
        #endregion

        #region Update
        /// <summary>
        /// Update a Contact
        /// </summary>
        /// <param name="contactDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Alterar([FromBody] ContactDTO contactDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            applicationServiceContact.Update(contactDTO);

            return Ok("Contact changed successfully!");

        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete a Contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            applicationServiceContact.Delete(id);

            return Ok("Contact deleted successfully!");
        }
        #endregion
    }
}