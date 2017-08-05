using Data.Repository;
using Domain.Entities;
using System.Linq;

namespace Service.Services
{
    public class ProdutoService : RepositoryBase<Produto>
    {
        public Produto ObterPorNome(string produto)
        {
            return Db.Set<Produto>().SingleOrDefault(p => p.Nome == produto);
        }
    }
}
