using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Domain.DTOs.Produto.Response;
using ProdutosApp.Domain.DTOs.ProdutoDtos.Request;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Services;

namespace ProdutosApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        #region Método Privado e Construtor

        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        #endregion

        [HttpPost]
        [Route("criar")]
        [ProducesResponseType(typeof(ProdutoResponseDto), 201)]
        public IActionResult Post(ProdutoRequestDto dto)
        {
            try
            {
                var fornecedor = new Fornecedor();
                var produto = new Produto()
                {
                    Id = Guid.NewGuid(),
                    Nome = dto.Nome,
                    Preco = dto.Preco,
                    Quantidade = dto.Quantidade,
                    FornecedorId = dto.FornecedorId,
                };
                _produtoService.Cadastrar(produto);

                var response = new ProdutoResponseDto()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    FornecedorId = produto.FornecedorId,
                };

                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }

            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
        }

        [HttpPut]
        [Route("editar")]
        [ProducesResponseType(typeof(ProdutoResponseDto), 200)]
        public IActionResult Put(ProdutoRequestDto dto)
        {
            try
            {
                var produto = new Produto()
                {
                    Id = Guid.NewGuid(),
                    Nome = dto.Nome,
                    Preco = dto.Preco,
                    Quantidade = dto.Quantidade,
                    FornecedorId = dto.FornecedorId,
                };
                _produtoService.Atualizar(produto);

                var response = new ProdutoResponseDto()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    FornecedorId = produto.FornecedorId,
                };

                return StatusCode(200, response);

            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutoResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var produto = _produtoService.GetById(id);
                _produtoService.Excluir(id);

                var response = new ProdutoResponseDto()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    FornecedorId = produto.FornecedorId,
                };
                
                return StatusCode(200, response);

            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
        }

        [HttpGet]
        [Route("consultar")]
        [ProducesResponseType(typeof(List<ProdutoResponseDto>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var response = _produtoService.GetAll();
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutoResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _produtoService.GetById(id);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
        }
    }
}
