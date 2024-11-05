using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Services
{
    public interface IFornecedorService
    {
        void Cadastrar(Fornecedor fornecedor);
        void Atualizar(Fornecedor fornecedor);
        void Excluir(Guid id);
        List<Fornecedor>? GetAll();
        Fornecedor? GetById(Guid id);

    }
}
