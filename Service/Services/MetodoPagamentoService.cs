using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;
using Domain.Entities;

namespace Service.Services
{
    public class MetodoPagamentoService : RepositoryBase<MetodoPagamento>
    {
        public MetodoPagamento ObterPorNome(string metodoPagamento)
        {
            return Db.Set<MetodoPagamento>().SingleOrDefault(mp => mp.Nome == metodoPagamento);
        }
    }
}
