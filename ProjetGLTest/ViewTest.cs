using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ProjetGLTest
{
    public class ViewTest
    : IClassFixture<WebApplicationFactory<ProjetGL.Startup>>
    {
        private readonly WebApplicationFactory<ProjetGL.Startup> _factory;

        public ViewTest(WebApplicationFactory<ProjetGL.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Index")]
        [InlineData("/Equipe/")]
        [InlineData("/Equipe/Edit/1")]
        [InlineData("/Joueur/")]
        [InlineData("/Joueur/Create/")]
        [InlineData("/Joueur/Edit/1")]
        [InlineData("/Match/")]

         
         
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
