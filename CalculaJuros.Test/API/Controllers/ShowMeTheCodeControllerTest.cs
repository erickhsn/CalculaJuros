using CalculaJuros.API.Controllers;
using CalculaJuros.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculaJuros.Test.API.Controllers
{
    public class ShowMeTheCodeControllerTest
    {
        [Fact]
        public void CalculaJuros_RetornaShowMeTheCode()
        {
            var expected = "https://github.com.br/erickhsn/CalculaJuros";
            var controller = new ShowMeTheCodeController();
            var actionResult = controller.ShowMeTheCode();

            var okResult = actionResult as OkObjectResult;

            Assert.Equal(expected, okResult.Value);
        }
    }
}
