using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        void Add(Produto produto);
        void Delete(Produto produto);
        void Update(Produto produto);
        List<Produto> GetAll();
        Produto? GetById(Guid id);
        Produto? GetByNome(string nome);
    }
}
