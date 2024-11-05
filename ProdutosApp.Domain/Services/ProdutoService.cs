using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        #region Metodos Privados e Construtores

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        #endregion

        #region Cadastrar Produto

        public void Cadastrar(Produto produto)
        {
            if (_produtoRepository.GetByNome(produto.Nome) != null)
            {
                throw new ApplicationException("O produto já foi cadastrado, tente outro.");
            }
            _produtoRepository.Add(produto);
        }

        #endregion

        #region Atualizar Produto

        public void Atualizar(Produto produto)
        {
            var updateProduto = _produtoRepository.GetById((Guid) produto.Id);
            if (updateProduto == null) 
            {
                throw new ApplicationException("Produto não encontrado");
            }

            updateProduto.Nome = produto.Nome;
            updateProduto.Preco = produto.Preco;
            updateProduto.Quantidade = produto.Quantidade;
            updateProduto.FornecedorId = produto.FornecedorId;

            _produtoRepository.Update(updateProduto);

        }

        #endregion

        #region Excluir Produto

        public void Excluir(Guid id)
        {
            var produto = _produtoRepository.GetById(id);
            if (produto == null)
            {
                throw new ApplicationException("Produto não foi encontrado");
            }

            _produtoRepository.Delete(produto);
        }

        #endregion

        #region Consultar Todos os Produtos

        public List<Produto> GetAll()
        {
            if (_produtoRepository.GetAll() == null)
            {
                throw new ApplicationException("Nenhum produto encontrado");
            }

            return _produtoRepository.GetAll();
        }

        #endregion

        #region Consultar por Id

        public Produto? GetById(Guid id)
        {
            if (_produtoRepository.GetById(id) == null)
            {
                throw new ApplicationException("Nenhum produto foi encontrado");
            }

            return _produtoRepository.GetById(id);    

        }

        #endregion

    }
}
