using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        int TotalRegistros(TEntity countEntity);

        IList<TEntity> ObterTodos();

        TEntity ObterPorId(Guid id);

        void ExcluirPorId(Guid id);

        void Excluir(TEntity entidadeEntity);

        void Dispose();

        void Salvar(TEntity entidadeEntity);

        void SalvarLista(IList<TEntity> entidadeEntity);

        void Atualizar(TEntity entidadeEntity);

        void AtualizarLista(IList<TEntity> entidadesEntity);

        IList<TEntity> PesquisarParametros(Expression<Func<TEntity, bool>> parametros);
    }
}
