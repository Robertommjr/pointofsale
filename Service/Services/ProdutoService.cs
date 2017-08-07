using System.Collections.Generic;
using Data.Repository;
using Domain.Entities;
using System.Linq;

namespace Service.Services
{
    public class ProdutoService : RepositoryBase<Produto>
    {
        private readonly CategoriaService _categoriaService = new CategoriaService();

        public Produto ObterPorNome(string produto)
        {
            return Db.Set<Produto>().SingleOrDefault(p => p.Nome == produto);
        }

        public IList<Produto> ObterTodosComCategoria()
        {
            var produtos = Db.Set<Produto>().ToList();

            foreach (var produto in produtos)
            {
                produto.Categoria = _categoriaService.ObterPorId(produto.CategoriaId);
            }

            return produtos;
        }
    }
}
