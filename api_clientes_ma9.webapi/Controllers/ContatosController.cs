using api_clientes_ma9.application.Abstracts;
using api_clientes_ma9.application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api_clientes_ma9.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        #region Construtor
        private readonly IContatoApplicationService applicationServiceContato;

        public ContatosController(IContatoApplicationService applicationServiceContato)
        {
            this.applicationServiceContato = applicationServiceContato;
        }
        #endregion

        #region Listar
        /// <summary>
        /// ListarTodos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ContatoDTO> Listar()
        {
            var contatos = applicationServiceContato.Listar();

            return new List<ContatoDTO>(contatos);
        }
        #endregion

        #region Obter
        /// <summary>
        /// Obter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ContatoDTO Obter(int id)
        {
            var contato = applicationServiceContato.Obter(id);

            return contato;
        }
        #endregion

        #region Inserir
        /// <summary>
        /// Inserir
        /// </summary>
        /// <param name="contatoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Inserir([FromBody] ContatoDTO contatoDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            applicationServiceContato.Inserir(contatoDTO);

            return Ok("Contato Cadastrado com sucesso!");
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="contatoDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Alterar([FromBody] ContatoDTO contatoDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            applicationServiceContato.Alterar(contatoDTO);

            return Ok("Contato Alterado com sucesso!");

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
            applicationServiceContato.Excluir(id);

            return Ok("Contato Removido com sucesso!");
        }
        #endregion
    }
}