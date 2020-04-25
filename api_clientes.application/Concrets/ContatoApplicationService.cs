using api_clientes.application.Abstracts;
using api_clientes.application.Models;
using api_clientes.cross.cutting.Abstracts;
using api_clientes.domain.Abstracts;
using System.Collections.Generic;

namespace api_clientes.application.Concrets
{
    public class ContatoApplicationService : IContatoApplicationService
    {
        #region Construtor
        private readonly IContatoService _serviceContato;
        private readonly IMapperContato _mapperContato;

        public ContatoApplicationService(IContatoService serviceContato, IMapperContato mapperContato)
        {
            this._serviceContato = serviceContato;
            this._mapperContato = mapperContato;
        }
        #endregion

        #region Listar
        /// <summary>
        /// Listar
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContatoDTO> Listar()
        {
            var contatos = _serviceContato.Listar();

            return _mapperContato.ListEntityToListDTO(contatos);
        }
        #endregion

        #region Obter
        /// <summary>
        /// Obter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContatoDTO Obter(int? id)
        {
            var contato = _serviceContato.Obter(id);

            return _mapperContato.EntityToDTO(contato);
        }
        #endregion

        #region Inserir
        /// <summary>
        /// Inserir
        /// </summary>
        /// <param name="contatoDTO"></param>
        public void Inserir(ContatoDTO contatoDTO)
        {
            var contato = _mapperContato.DTOToEntity(contatoDTO);
            
            _serviceContato.Inserir(contato);
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="contatoDTO"></param>
        public void Alterar(ContatoDTO contatoDTO)
        {
            var cliente = _mapperContato.DTOToEntity(contatoDTO);

            _serviceContato.Alterar(cliente);
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(int? id)
        {
            _serviceContato.Excluir(id);
        }
        #endregion
    }
}
