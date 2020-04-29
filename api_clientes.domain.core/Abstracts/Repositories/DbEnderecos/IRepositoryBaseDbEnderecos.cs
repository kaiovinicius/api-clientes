using System.Collections.Generic;

namespace api_clientes.domain.core.Abstracts.Repositories.DbEnderecos
{
    public interface IRepositoryBaseDbEnderecos<TEntity> where TEntity : class
    {
        #region Listar
        List<TEntity> Listar();
        #endregion

        #region Obter
        TEntity Obter(int? id);
        #endregion

        #region Inserir
        void Inserir(TEntity entidade);
        #endregion

        #region Alterar
        void Alterar(TEntity entidade);
        #endregion

        #region Excluir
        void Excluir(int? id);
        #endregion
    }
}
