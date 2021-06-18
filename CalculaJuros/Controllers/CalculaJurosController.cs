using CalculaJuros.API.ClientRequest;
using CalculaJuros.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CalculaJuros.Controllers
{
    public class CalculaJurosController : ControllerBase
    {
        private readonly ITaxaJurosClientRequest _taxaJurosClientRequest;
        public CalculaJurosController(ITaxaJurosClientRequest taxaJurosClientRequest)
        {
            _taxaJurosClientRequest = taxaJurosClientRequest;
        }

        [Route("calculajuros")]
        [HttpGet]
        public IActionResult CalculaJuros(decimal valorInicial, int meses)
        {
            Decimal juros = _taxaJurosClientRequest.GetTaxaDeJuros();
            string valorFinal = ((double)valorInicial * Math.Pow(1 + (double)juros, meses)).ToString("N2");
            var result = new TaxaDeJurosResult() { ValorFinal = valorFinal };
            return Ok(result);
        }

    }
}
