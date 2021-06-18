using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.API.ClientRequest
{
    public class TaxaJurosClientRequest : HttpClientRequest, ITaxaJurosClientRequest
    {
        public TaxaJurosClientRequest(HttpClient httpClient) : base(httpClient)
        {
        }
        public decimal GetTaxaDeJuros()
        {
            var response = JsonConvert.DeserializeObject<TaxaDeJurosResponse>(GetRequest("15029f16-0080-41ec-b620-5c448cb25e61").Result);
            var taxaJurosDecimal = decimal.Parse(response.TaxaJuros.ToString());
            return taxaJurosDecimal;
        }
    }
}
