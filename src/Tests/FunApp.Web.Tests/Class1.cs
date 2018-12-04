using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FunApp.Web.Tests
{
    public class Class1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> server;

        public Class1(WebApplicationFactory<Startup> server)
        {
            this.server = server;
        }

        [Fact]
        public async Task IndexPageShouldReturnStatusCode200()
        {
            var client = this.server.CreateClient();
            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("<title>", responseContent);
        }

        [Fact]
        public async Task JokesCreatePageRequiredAuthorization()
        {
            var client = this.server.CreateClient(
                new WebApplicationFactoryClientOptions
                {AllowAutoRedirect = false});
            var response = await client.GetAsync("/Jokes/Create");
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }
    }
}
