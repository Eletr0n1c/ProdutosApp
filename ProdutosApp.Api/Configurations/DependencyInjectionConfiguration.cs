using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Domain.Interfaces.Services;
using ProdutosApp.Domain.Services;
using ProdutosApp.Infra.Data.Repositories;

namespace ProdutosApp.Api.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            #region Adicionando as injeções de dependência do projeto

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IFornecedorRepository, FornecedorRepository>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IFornecedorService, FornecedorService>();

            #endregion
        }
    }
}
