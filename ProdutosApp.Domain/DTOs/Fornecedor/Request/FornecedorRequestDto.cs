using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.DTOs.FornecedorDtos.Request
{
    public class FornecedorRequestDto
    {
        [MaxLength(50, ErrorMessage = "Digite um nome com no máximo 100 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do fornecedor.")]
        public string? Nome { get; set; }
    }
}
