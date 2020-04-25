using api_clientes.application.Abstracts;
using api_clientes.application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api_clientes.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        #region Construtor
        private readonly IClienteApplicationService applicationServiceCliente;

        public ClientesController(IClienteApplicationService applicationServiceCliente)
        {
            this.applicationServiceCliente = applicationServiceCliente;
        }
        #endregion

        #region Listar
        /// <summary>
        /// ListarTodos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ClienteDTO> Listar()
        {
            var clientes = applicationServiceCliente.Listar();

            return new List<ClienteDTO>(clientes);
        }
        #endregion

        #region Obter
        /// <summary>
        /// Obter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ClienteDTO Obter(int id)
        {
            var cliente = applicationServiceCliente.Obter(id);
            
            return cliente;
        }
        #endregion

        #region Inserir
        /// <summary>
        /// Inserir
        /// </summary>
        /// <param name="clienteDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Inserir([FromBody] ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            applicationServiceCliente.Inserir(clienteDTO);

            return Ok("Cliente Cadastrado com sucesso!");
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="clienteDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Alterar([FromBody] ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            applicationServiceCliente.Alterar(clienteDTO);

            return Ok("Cliente Alterado com sucesso!");
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Excluir(int id)
        {

            applicationServiceCliente.Excluir(id);
                
            return Ok("Cliente Removido com sucesso!");
        } 
        #endregion
    }
}