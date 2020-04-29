using api_clientes.application.DTO.Models;
using api_clientes.cross.cutting.Abstracts;
using api_clientes.domain.core.Abstracts.Services;
using api_clientes.application.Abstracts;
using System.Collections.Generic;

namespace api_clientes.application.Concrets
{
    public class EnderecoApplicationService : IEnderecoApplicationService
    {
        #region Construtor
        private readonly IEnderecoService _serviceEndereco;
        private readonly IMapperEndereco _mapperEndereco;

        public EnderecoApplicationService(IEnderecoService serviceEndereco, IMapperEndereco mapperEndereco)
        {
            this._mapperEndereco = mapperEndereco;
            this._serviceEndereco = serviceEndereco;
        }
        #endregion

        #region Listar
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EnderecoDTO> Listar()
        {
            var enderecos = _serviceEndereco.Listar();

            return _mapperEndereco.ListEntityToListDTO(enderecos);
        }
        #endregion

        #region Obter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EnderecoDTO Obter(int? id)
        {
            var endereco = _serviceEndereco.Obter(id);

            return _mapperEndereco.EntityToDTO(endereco);
        }
        #endregion

        #region Inserir
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enderecoDTO"></param>
        public void Inserir(EnderecoDTO enderecoDTO)
        {
            var endereco = _mapperEndereco.DTOToEntity(enderecoDTO);
            _serviceEndereco.Inserir(endereco);
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="enderecoDTO"></param>
        public void Alterar(EnderecoDTO enderecoDTO)
        {
            var endereco = _mapperEndereco.DTOToEntity(enderecoDTO);

            _serviceEndereco.Alterar(endereco);
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(int? id)
        {
            _serviceEndereco.Excluir(id);
        }
        #endregion
    }
}
