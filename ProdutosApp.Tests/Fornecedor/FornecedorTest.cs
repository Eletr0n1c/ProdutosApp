using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProdutosApp.Domain.DTOs.FornecedorDtos.Request;
using ProdutosApp.Domain.DTOs.FornecedorDtos.Response;
using System.Net;
using System.Text;

namespace ProdutosApp.Tests.Fornecedor
{
    public class FornecedorTest
    {
        [Fact]
        public void CriarFornecedorComSucessoTest()
        {
            var faker = new Faker("pt_BR");

            var request = new FornecedorRequestDto
            {
                Nome = faker.Person.FullName
            };

            var jsonRequest = new StringContent
                (JsonConvert.SerializeObject (request),
                Encoding.UTF8, "application/json");

            var client = new WebApplicationFactory<Program>().CreateClient();

            var response = client.PostAsync("/api/fornecedor/criar", jsonRequest).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public void ExcluirFornecedorComSucessoTest()
        {
            var faker = new Faker("pt_BR");

            var request = new FornecedorRequestDto()
            {
                Nome =  faker.Person.FullName
            };

            var jsonRequest = new StringContent
                (JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");

            var client = new WebApplicationFactory
                <Program>().CreateClient();
            var createResponse = client.PostAsync("/api/fornecedor/criar", jsonRequest).Result;

            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var criarFornecedor = JsonConvert.DeserializeObject<FornecedorResponseDto>(
    createResponse.Content.ReadAsStringAsync().Result);
            criarFornecedor.Should().NotBeNull();

            var fornecedorId = criarFornecedor.Id;

            var deleteFornecedor = client.DeleteAsync($"/api/fornecedor/{fornecedorId}").Result;

            deleteFornecedor.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public void ConsultarFornecedorComSucessoTest()
        {
            // Configuração
            var client = new WebApplicationFactory<Program>().CreateClient();

            // Ação: Faz uma requisição GET para consultar a lista de fornecedores
            var response = client.GetAsync("/api/fornecedor/consultar").Result;

            // Verificação: O status da resposta deve ser OK
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Verificação: A resposta deve conter uma lista de fornecedores
            var fornecedores = JsonConvert.DeserializeObject<List<FornecedorResponseDto>>(response.Content.ReadAsStringAsync().Result);
            fornecedores.Should().NotBeNull();
            fornecedores.Should().NotBeEmpty(); // Considerando que haja pelo menos um fornecedor na lista
        }

        [Fact]
        public void ConsultarPorIdComSucessoTest()
        {
            // Configuração: Cria um fornecedor inicial
            var faker = new Faker("pt_BR");
            var createRequest = new FornecedorRequestDto
            {
                Nome = faker.Person.FullName
            };

            var jsonCreateRequest = new StringContent(
                JsonConvert.SerializeObject(createRequest),
                Encoding.UTF8, "application/json");

            var client = new WebApplicationFactory<Program>().CreateClient();
            var createResponse = client.PostAsync("/api/fornecedor/criar", jsonCreateRequest).Result;

            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            // Extrai o ID do fornecedor criado
            var createdFornecedor = JsonConvert.DeserializeObject<FornecedorResponseDto>(
                createResponse.Content.ReadAsStringAsync().Result);
            createdFornecedor.Should().NotBeNull();
            var fornecedorId = createdFornecedor.Id;

            // Ação: Faz uma requisição GET para consultar o fornecedor pelo Id
            var response = client.GetAsync($"/api/fornecedor/{fornecedorId}").Result;

            // Verificação: O status da resposta deve ser OK
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Verificação: A resposta deve conter o fornecedor com o Id correto
            var fornecedorConsultado = JsonConvert.DeserializeObject<FornecedorResponseDto>(response.Content.ReadAsStringAsync().Result);
            fornecedorConsultado.Should().NotBeNull();
            fornecedorConsultado.Id.Should().Be(fornecedorId);
            fornecedorConsultado.Nome.Should().Be(createRequest.Nome);
        }

    }
}
