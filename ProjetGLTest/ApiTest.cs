using System;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using Xunit.Abstractions;

namespace ProjetGLTest
{
    public class ApiTest
    : IClassFixture<WebApplicationFactory<ProjetGL.Startup>>
    {
        private readonly WebApplicationFactory<ProjetGL.Startup> _factory;
        // Permet le déboggage en donnant un accès à l'écriture en console
        private readonly ITestOutputHelper output;

        public ApiTest(ITestOutputHelper output, WebApplicationFactory<ProjetGL.Startup> factory)
        {
            this.output = output;
            _factory = factory;
        }


        [Theory]
        [InlineData("/api/EquipeApi")]
        [InlineData("/api/MatchApi")]
        [InlineData("/api/JoueurApi")]
        
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

       
    }
}