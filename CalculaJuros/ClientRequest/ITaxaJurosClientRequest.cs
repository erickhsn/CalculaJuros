using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculaJuros.API.ClientRequest
{
    public interface ITaxaJurosClientRequest
    {
        public decimal GetTaxaDeJuros();
    }
}
