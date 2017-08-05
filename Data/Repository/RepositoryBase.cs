using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbContext = Data.Context.DbContext;

namespace Data.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext Db = new DbContext();

        public int TotalRegistros(TEntity entidadeEntity)
        {
            return Db.Set<TEntity>().Count();
        }

        public IList<TEntity> ObterTodos()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IList<TEntity> ObterTodosLazyLoad()
        {
            Db.Configuration.LazyLoadingEnabled = false;
            return Db.Set<TEntity>().ToList();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return Db.Set<TEntity>().Find(id);
        }
        public virtual TEntity ObterPorIdLazyLoad(Guid id)
        {
            Db.Configuration.LazyLoadingEnabled = false;
            return Db.Set<TEntity>().Find(id);
        }

        public void ExcluirPorId(Guid id)
        {
            var entidade = Db.Set<TEntity>().Find(id);
            if (entidade != null) Db.Set<TEntity>().Remove(entidade);
            Db.SaveChanges();
        }

        public virtual void Excluir(TEntity entidadeEntity)
        {
            Db.Set<TEntity>().Remove(entidadeEntity);
            Db.SaveChanges();
        }

        public virtual void Salvar(TEntity entidadeEntity)
        {
            Db.Set<TEntity>().Add(entidadeEntity);
            Db.SaveChanges();
        }

        public void SalvarLista(IList<TEntity> entidadeEntity)
        {
            foreach (var Entity in entidadeEntity)
            {
                Db.Set<TEntity>().Add(Entity);
            }
            Db.SaveChanges();
        }

        public virtual void Atualizar(TEntity entidadeEntity)
        {
            Db.Entry(entidadeEntity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public virtual void AtualizarLista(IList<TEntity> entidadesEntity)
        {
            foreach (var entity in entidadesEntity)
            {
                Db.Entry(entity).State = EntityState.Modified;
            }

            Db.SaveChanges();
        }

        public IList<TEntity> PesquisarParametros(Expression<Func<TEntity, bool>> parametros)
        {
            return Db.Set<TEntity>().Where(parametros).ToList();
        }

        public virtual async Task<string> SalvarAsync(TEntity entidadeEntity)
        {
            Db.Set<TEntity>().Add(entidadeEntity);
            await Db.SaveChangesAsync();
            return "Entidade adicionada com sucesso";
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
