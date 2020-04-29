using api_clientes.domain.Entities;

namespace api_clientes.domain.core.Abstracts.Repositories.DbClientes
{
    public interface IContatoRepository : IRepositoryBaseDbClientes<Contato>
    {
        #region ObterPorIdCliente
        /// <summary>
        /// Obtém Contato por Id do Cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        Contato ObterPorIdCliente(int? idCliente); 
        #endregion
    }
}
