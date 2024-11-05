using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.DTOs.ProdutoDtos.Request
{
    public class ProdutoRequestDto
    {
        [MaxLength(150, ErrorMessage = "Digite um nome com no máximo {1} caracteres")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preço do produto")]
        public Decimal? Preco { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade do produto")]
        public int? Quantidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do fornecedor")]
        public Guid? FornecedorId { get; set; }
    }
}
