using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProdutosApp.Domain.DTOs.Produto.Response;
using ProdutosApp.Domain.DTOs.ProdutoDtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using ProdutosApp.Tests.Fornecedor;
using ProdutosApp.Domain.DTOs.FornecedorDtos.Request;
using ProdutosApp.Domain.DTOs.FornecedorDtos.Response;
using Bogus.Extensions.UnitedKingdom;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace ProdutosApp.Tests.Produto
{
    public class ProdutoTest
    {

        [Fact]
        public void CriarProdutoComSucessoTest()
        {
            #region Criando um Fornecedor

            var faker = new Faker("pt_BR");

            var requestFornecedor = new FornecedorRequestDto
            {
                Nome = faker.Person.FullName
            };

            var jsonRequest = new StringContent
                (JsonConvert.SerializeObject(requestFornecedor),
                Encoding.UTF8, "application/json");

            var clientFornecedor = new WebApplicationFactory<Program>().CreateClient();

            var fornecedorResponse = clientFornecedor.PostAsync("/api/fornecedor/criar", jsonRequest).Result;

            fornecedorResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            // Extrai o ID do fornecedor criado
            var createdFornecedor = JsonConvert.DeserializeObject<FornecedorResponseDto>(
                fornecedorResponse.Content.ReadAsStringAsync().Result);
            createdFornecedor.Should().NotBeNull();
            var fornecedorId = createdFornecedor.Id;

            #endregion

            var request = new ProdutoRequestDto()
            {
                Nome = faker.Person.FullName,
                Preco = faker.Random.Decimal(1, 1000),
                Quantidade = faker.Random.Int(1, 1000),
                FornecedorId = fornecedorId
            };

            var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var client = new WebApplicationFactory<Program>().CreateClient();

            var response = client.PostAsync("/api/produtos/criar", json).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public void ExcluirProdutoComSucessoTest()
        {
            #region Criando um Produto

            #region Criando um Fornecedor

            var faker = new Faker("pt_BR");

            var requestFornecedor = new FornecedorRequestDto
            {
                Nome = faker.Person.FullName
            };

            var jsonRequest = new StringContent
                (JsonConvert.SerializeObject(requestFornecedor),
                Encoding.UTF8, "application/json");

            var clientFornecedor = new WebApplicationFactory<Program>().CreateClient();

            var fornecedorResponse = clientFornecedor.PostAsync("/api/fornecedor/criar", jsonRequest).Result;

            fornecedorResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            // Extrai o ID do fornecedor criado
            var createdFornecedor = JsonConvert.DeserializeObject<FornecedorResponseDto>(
                fornecedorResponse.Content.ReadAsStringAsync().Result);
            createdFornecedor.Should().NotBeNull();
            var fornecedorId = createdFornecedor.Id;

            #endregion

            var request = new ProdutoRequestDto()
            {
                Nome = faker.Person.FullName,
                Preco = faker.Random.Decimal(1, 1000),
                Quantidade = faker.Random.Int(1, 1000),
                FornecedorId = fornecedorId
            };

            var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var client = new WebApplicationFactory<Program>().CreateClient();

            var response = client.PostAsync("/api/produtos/criar", json).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            #endregion

            var produtoResponse = JsonConvert.DeserializeObject<ProdutoResponseDto>(response.Content.ReadAsStringAsync().Result);
            produtoResponse.Should().NotBeNull();
            var produtoId = produtoResponse.Id;

            var deletarProduto = client.DeleteAsync($"/api/produtos/{produtoId}").Result;

            deletarProduto.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public void ConsultarProdutoComSucessoTest()
        {
            var client = new WebApplicationFactory<Program>().CreateClient();

            var response = client.GetAsync("/api/produtos/consultar").Result;

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var produtos = JsonConvert.DeserializeObject<List<ProdutoResponseDto>>(response.Content.ReadAsStringAsync().Result);
            produtos.Should().NotBeNull();
            produtos.Should().NotBeEmpty();
        }

        [Fact]
        public void ConsultarPorIdComSucessoTest()
        {
            #region Criando um Produto

            #region Criando um Fornecedor

            var faker = new Faker("pt_BR");

            var requestFornecedor = new FornecedorRequestDto
            {
                Nome = faker.Person.FullName
            };

            var jsonRequest = new StringContent
                (JsonConvert.SerializeObject(requestFornecedor),
                Encoding.UTF8, "application/json");

            var clientFornecedor = new WebApplicationFactory<Program>().CreateClient();

            var responseFornecedor = clientFornecedor.PostAsync("/api/fornecedor/criar", jsonRequest).Result;

            responseFornecedor.StatusCode.Should().Be(HttpStatusCode.Created);

            // Extrai o ID do fornecedor criado
            var createdFornecedor = JsonConvert.DeserializeObject<FornecedorResponseDto>(
                responseFornecedor.Content.ReadAsStringAsync().Result);
            createdFornecedor.Should().NotBeNull();
            var fornecedorId = createdFornecedor.Id;

            #endregion

            var request = new ProdutoRequestDto()
            {
                Nome = faker.Person.FullName,
                Preco = faker.Random.Decimal(1, 1000),
                Quantidade = faker.Random.Int(1, 1000),
                FornecedorId = fornecedorId
            };

            var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var client = new WebApplicationFactory<Program>().CreateClient();

            var responseProduto = client.PostAsync("/api/produtos/criar", json).Result;

            responseProduto.StatusCode.Should().Be(HttpStatusCode.Created);

            #endregion

            var produtoResponse = JsonConvert.DeserializeObject<ProdutoResponseDto>(responseProduto.Content.ReadAsStringAsync().Result);
            produtoResponse.Should().NotBeNull();
            var produtoId = produtoResponse.Id;

            var response = client.GetAsync($"/api/produtos/{produtoId}").Result;

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Verificação: A resposta deve conter o fornecedor com o Id correto
            var produtoConsultado = JsonConvert.DeserializeObject<ProdutoResponseDto>(response.Content.ReadAsStringAsync().Result);
            produtoConsultado.Should().NotBeNull();
            produtoConsultado.Id.Should().Be(produtoId);
            produtoConsultado.Nome.Should().Be(request.Nome);
            produtoConsultado.Quantidade.Should().Be(request.Quantidade);
            produtoConsultado.FornecedorId.Should().Be(fornecedorId);
        }
    }
}
