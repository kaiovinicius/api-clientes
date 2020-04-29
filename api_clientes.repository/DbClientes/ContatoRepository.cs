using api_clientes.data;
using api_clientes.domain.core.Abstracts.Repositories.DbClientes;
using api_clientes.domain.Entities;
using api_clientes.repository.DbClientes;
using System.Linq;

namespace api_clientes.repository
{
    public class ContatoRepository : RepositoryBaseClientes<Contato>, IContatoRepository
    {
        #region Construtor
        private readonly ClientesContext _context;

        public ContatoRepository(ClientesContext context) : base(context)
        {
            this._context = context;
        }
        #endregion

        #region Alterar
        public override void Alterar(Contato entidade)
        {
            this.DetachedLocal(c => c.Id == entidade.Id);

            base.Alterar(entidade);
        }
        #endregion

        #region ObterPorIdCliente
        public Contato ObterPorIdCliente(int? idCliente)
        {
            var consulta = from c in _context.Contatos
                           .Where(c => c.IdCliente == idCliente)
                           select c;

            return consulta.SingleOrDefault();
        } 
        #endregion
    }
}
