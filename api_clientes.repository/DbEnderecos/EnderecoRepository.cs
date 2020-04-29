using api_clientes.data;
using api_clientes.domain.core.Abstracts.Repositories.DbEnderecos;
using api_clientes.domain.Entities;
using api_clientes.repository.DbEnderecos;

namespace api_clientes.repository
{
    public class EnderecoRepository : RepositoryBaseEndereco<Endereco>, IEnderecoRepository
    {
        #region Construtor
        private readonly EnderecosContext _context;

        public EnderecoRepository(EnderecosContext context) : base(context)
        {
            this._context = context;
        } 
        #endregion
    }
}
