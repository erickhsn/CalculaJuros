using CalculaJuros.API.ClientRequest;
using CalculaJuros.API.Models;
using CalculaJuros.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculaJuros.Test.API.Controllers
{
    public class CalculaJurosControllerTest
    {
        [Theory]
        [InlineData(0, 1, "0,00")]
        [InlineData(1, 3, "1,03")]
        [InlineData(100, 5, "105,10")]
        public void CalculaJuros_RetornaOCalculoDeJuros_ValorCorreto(decimal valorInicial, int meses, string expected)
        {
            var mock = new Mock<ITaxaJurosClientRequest>();
            mock.Setup(tj => tj.GetTaxaDeJuros()).Returns(0.01M);
            var controller = new CalculaJurosController(mock.Object);
            var actionResult = controller.CalculaJuros(valorInicial, meses);

            var okResult = actionResult as OkObjectResult;
            var result = okResult.Value as TaxaDeJurosResult;

            Assert.Equal(expected, result.ValorFinal);
        }
    }
}
