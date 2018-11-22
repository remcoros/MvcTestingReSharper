using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using MvcTestingReSharper;
using Xunit;

namespace Tests
{
    public class ValuesControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _webapp;

        public ValuesControllerTests(WebApplicationFactory<Startup> webapp)
        {
            _webapp = webapp;
        }

        [Fact]
        public async Task CanGetValues()
        {
            var client = _webapp.CreateClient();
            var response = await client.GetAsync("/api/values/1");
            
            response.EnsureSuccessStatusCode();

            var value = await response.Content.ReadAsStringAsync();
            
            Assert.Equal("value", value);
        }
    }
}
