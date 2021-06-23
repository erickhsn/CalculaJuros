using CalculaJuros.API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
    public class CalculaJurosEndpointTest
    {
        [Fact]
        public async Task CalculaJurosEndPointTest_ReturnaOk()
        {
            var expected = "{\"valorFinal\":\"105,10\"}";
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseStartup<CalculaJuros.Startup>();
                });

            var host = await hostBuilder.StartAsync();

            var client = host.GetTestClient();

            var response = await client.GetAsync("CalculaJuros?valorinicial=100&meses=5");
            var result = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expected, result);
            
        }

        [Fact]
        public async Task CalculaJurosEndPointTest_RetornaErro()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseStartup<CalculaJuros.Startup>();
                });

            var host = await hostBuilder.StartAsync();

            var client = host.GetTestClient();

            var response = await client.GetAsync("CalculaJuros?valorinicial=0&meses=0");
            var result = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [Fact]
        public async Task CalculaJurosEndPointTest_RetornaErro_ParamêtrosNulo()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseStartup<CalculaJuros.Startup>();
                });

            var host = await hostBuilder.StartAsync();

            var client = host.GetTestClient();

            var response = await client.GetAsync("CalculaJuros");
            var result = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }
    }
}
