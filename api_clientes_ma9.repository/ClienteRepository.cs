using api_clientes_ma9.data;
using api_clientes_ma9.Data_Acess.Abstracts.Repositories;
using api_clientes_ma9.Entities;

namespace api_clientes_ma9.repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        #region Construtor
        private readonly Ma9_ClientesContext _context;

        public ClienteRepository(Ma9_ClientesContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region Alterar
        public override void Alterar(Cliente entidade)
        {
            this.DetachedLocal(c => c.Id == entidade.Id);

            base.Alterar(entidade);
        } 
        #endregion
    }
}
