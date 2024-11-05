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
    public class FornecedorService : IFornecedorService
    {
        #region Metodos Privados e Construtor

        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        #endregion

        #region Cadastrar Fornecedor

        public void Cadastrar(Fornecedor fornecedor)
        {
            if (_fornecedorRepository.GetByNome(fornecedor.Nome) != null) 
            {
                throw new ApplicationException("O fornecedor já existe, cadastre outro.");
            }
            _fornecedorRepository.Add(fornecedor);
        }

        #endregion

        #region Atualizar Fornecedor

        public void Atualizar(Fornecedor fornecedor)
        {
            var updateFornecedor = _fornecedorRepository.GetById((Guid) fornecedor.Id);
            if (updateFornecedor == null)
            {
                throw new ApplicationException("O fornecedor não foi encontrado ou não existe");
            }

            //Dados que serão atualizados
            updateFornecedor.Nome = fornecedor.Nome;

            _fornecedorRepository.Update(updateFornecedor);
        }

        #endregion

        #region Excluir Fornecedor

        public void Excluir(Guid id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);
            if (fornecedor == null)
            {
                throw new ApplicationException("O fornecedor não foi encotrado");
            }
            _fornecedorRepository.Delete(fornecedor);
        }

        #endregion

        #region Consultar Todos

        public List<Fornecedor>? GetAll()
        {
            if (_fornecedorRepository.GetAll() == null)
            {
                throw new ApplicationException("Nenhum fornecedor foi encontrado");
            }
            return _fornecedorRepository.GetAll();
        }

        #endregion

        #region Consultar por Id

        public Fornecedor? GetById(Guid id)
        {
            if (_fornecedorRepository.GetById(id) == null)
            {
                throw new ApplicationException("Nenhum fornecedor encontrado");
            }
            return _fornecedorRepository.GetById(id);
        }

        #endregion


    }
}
