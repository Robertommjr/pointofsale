using Data.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoriaService : RepositoryBase<Categoria>
    {
        public Categoria ObterPorNome(string categoria)
        {
            return Db.Set<Categoria>().SingleOrDefault(c => c.Nome == categoria);
        }
    }
}
