using api_clientes_ma9.application.abstracts;
using api_clientes_ma9.application.dto;
using api_clientes_ma9.cross.cutting.Abstracts;
using api_clientes_ma9.domain.Abstracts;
using System.Collections.Generic;

namespace api_clientes_ma9.application.Concrets
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        #region Construtor
        private readonly IClienteService _serviceCliente;
        private readonly IMapperCliente _mapperCliente;

        public ClienteApplicationService(IClienteService serviceCliente, IMapperCliente mapperCliente)
        {
            this._mapperCliente = mapperCliente;
            this._serviceCliente = serviceCliente;
        }
        #endregion

        #region Listar
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClienteDTO> Listar()
        {
            var clientes = _serviceCliente.Listar();

            return _mapperCliente.ListClienteToDTO(clientes);
        }
        #endregion

        #region Obter
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClienteDTO Obter(int? id)
        {
            var cliente = _serviceCliente.Obter(id);

            return _mapperCliente.EntityToDTO(cliente);
        }
        #endregion

        #region Inserir
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clienteDTO"></param>
        public void Inserir(ClienteDTO clienteDTO)
        {
            var cliente = _mapperCliente.DTOToEntity(clienteDTO);
            _serviceCliente.Inserir(cliente);
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="clienteDTO"></param>
        public void Alterar(ClienteDTO clienteDTO)
        {
            var cliente = _mapperCliente.DTOToEntity(clienteDTO);

            _serviceCliente.Alterar(cliente);
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(int? id)
        {
            _serviceCliente.Excluir(id);
        }
        #endregion
    }
}
