using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Repositories
{
    public interface IFornecedorRepository
    {
        void Add(Fornecedor fornecedor);
        void Update(Fornecedor fornecedor);
        void Delete(Fornecedor fornecedor);
        List<Fornecedor> GetAll();
        Fornecedor? GetById(Guid id);
        Fornecedor? GetByNome(string nome);
    }
}
