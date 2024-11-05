using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public void Add(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(produto);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Produto produto)
        {
            using(var dataContext = new DataContext())
            {
                dataContext.Remove(produto);
                dataContext.SaveChanges();
            }
        }

        public void Update(Produto produto)
        {
            using(var dataContext = new DataContext())
            {
                dataContext.Update(produto);
                dataContext.SaveChanges();
            }
        }

        public List<Produto> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Produto>()
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
        }

        public Produto? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Produto>()
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public Produto? GetByNome(string nome)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Produto>()
                    .FirstOrDefault(p => p.Nome.Equals(nome));
            }
        }
    }
}
