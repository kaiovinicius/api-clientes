using api_clientes.application.Abstracts;
using api_clientes.application.DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api_clientes.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        #region Construtor
        private readonly IEnderecoApplicationService applicationServiceEndereco;

        public EnderecosController(IEnderecoApplicationService applicationServiceEndereco)
        {
            this.applicationServiceEndereco = applicationServiceEndereco;
        }
        #endregion

        #region Listar
        /// <summary>
        /// Listar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<EnderecoDTO> Listar()
        {
            var enderecos = applicationServiceEndereco.Listar();

            return new List<EnderecoDTO>(enderecos);
        }
        #endregion

        #region Obter
        /// <summary>
        /// Obter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public EnderecoDTO Obter(int id)
        {
            var endereco = applicationServiceEndereco.Obter(id);

            return endereco;
        }
        #endregion

        #region Inserir
        /// <summary>
        /// Inserir
        /// </summary>
        /// <param name="enderecoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Inserir([FromBody] EnderecoDTO enderecoDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            applicationServiceEndereco.Inserir(enderecoDTO);

            return Ok("Endereco Cadastrado com sucesso!");
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="enderecoDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Alterar([FromBody] EnderecoDTO enderecoDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            applicationServiceEndereco.Alterar(enderecoDTO);

            return Ok("Endereco Alterado com sucesso!");

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
            applicationServiceEndereco.Excluir(id);

            return Ok("Endereco Removido com sucesso!");
        }
        #endregion
    }
}