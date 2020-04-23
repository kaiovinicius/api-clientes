
using api_clientes_ma9.Entities;

namespace api_clientes_ma9.Data_Acess.Abstracts.Repositories
{
    public interface IContatoRepository : IRepositoryBase<Contato>
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
