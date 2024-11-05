using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        void Cadastrar(Produto produto);
        void Atualizar(Produto produto);
        void Excluir(Guid id);
        List<Produto> GetAll();
        Produto? GetById(Guid id);
    }
}
