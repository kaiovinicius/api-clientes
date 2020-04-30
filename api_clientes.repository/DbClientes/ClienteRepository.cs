using api_clientes.data;
using api_clientes.domain.core.Abstracts.Repositories.DbClientes;
using api_clientes.domain.Entities;
using api_clientes.repository.DbClientes;

namespace api_clientes.repository
{
    public class ClienteRepository : RepositoryBaseClientes<Cliente>, IClienteRepository
    {
        #region Construtor
        private readonly ClientesContext _context;

        public ClienteRepository(ClientesContext context) : base(context)
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