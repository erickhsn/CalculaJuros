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

        /// <summary>
        /// Pega o valor total da taxa de juros
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="meses"></param>
        /// <returns></returns>
        /// <response code="200">Retorna a taxa de juros</response>
        /// <response code="400">Caso os paramêtros não atendam as regras de não serem nulos ou serem menor ou igual que 0</response>  
        [Route("calculajuros")]
        [HttpGet]
        public IActionResult CalculaJuros(decimal? valorInicial, int? meses)
        {
            if ((!valorInicial.HasValue && !meses.HasValue) || (valorInicial <= 0 && meses <= 0 ))
            {
                return BadRequest("Insira todos os parametros corretamente");
            }
            Decimal juros = _taxaJurosClientRequest.GetTaxaDeJuros();
            string valorFinal = ((double)valorInicial * Math.Pow(1 + (double)juros, (int)meses)).ToString("N2");
            var result = new TaxaDeJurosResult() { ValorFinal = valorFinal };
            return Ok(result);
        }

    }
}
