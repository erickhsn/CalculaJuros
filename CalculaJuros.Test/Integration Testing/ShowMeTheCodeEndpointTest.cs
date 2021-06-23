using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculaJuros.Test.Integration_Testing
{
    public class ShowMeTheCodeEndpointTest
    {
        [Fact]
        public async Task ShowMeTheCodePointTest_ReturnaOk()
        {
            var expected = "https://github.com.br/erickhsn/CalculaJuros";
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseStartup<CalculaJuros.Startup>();
                });

            var host = await hostBuilder.StartAsync();

            var client = host.GetTestClient();

            var response = await client.GetAsync("ShowMeTheCode");
            var result = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expected, result);

        }
    }
}
