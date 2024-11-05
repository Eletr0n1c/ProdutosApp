using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.DTOs.Produto.Response
{
    public class ProdutoResponseDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public Decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public Guid? FornecedorId { get; set; }
    }
}
