using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Domain.DTOs.FornecedorDtos.Request;
using ProdutosApp.Domain.DTOs.FornecedorDtos.Response;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Services;

namespace ProdutosApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        #region Metodos Privados e Construtor

        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        #endregion


        [HttpPost]
        [Route("criar")]
        [ProducesResponseType(typeof(FornecedorResponseDto), 201)]
        public IActionResult Post(FornecedorRequestDto dto)
        {
            try
            {
                var fornecedor = new Fornecedor()
                {
                    Id = Guid.NewGuid(),
                    Nome = dto.Nome,
                };
                _fornecedorService.Cadastrar(fornecedor);

                var response = new FornecedorResponseDto
                {
                    Id = fornecedor.Id,
                    Nome = fornecedor.Nome,
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
        [ProducesResponseType(typeof(FornecedorResponseDto), 200)]
        public IActionResult Put(FornecedorResponseDto dto) 
        {
            try
            {
                var fornecedor = new Fornecedor()
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                };
                _fornecedorService.Atualizar(fornecedor);

                var response = new FornecedorResponseDto()
                {
                    Nome = dto.Nome,
                    Id = fornecedor.Id,
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
        [ProducesResponseType(typeof(FornecedorResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var fornecedor = _fornecedorService.GetById(id);
                _fornecedorService.Excluir(id);

                var response = new FornecedorResponseDto()
                {
                    Id = fornecedor.Id,
                    Nome = fornecedor.Nome,
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
        [ProducesResponseType(typeof(FornecedorResponseDto), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var response = _fornecedorService.GetAll();
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
        [ProducesResponseType(typeof(FornecedorResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _fornecedorService.GetById(id);

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
