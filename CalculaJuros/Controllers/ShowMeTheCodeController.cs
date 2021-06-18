using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculaJuros.API.Controllers
{
    public class ShowMeTheCodeController : ControllerBase
    {
        [Route("showmethecode")]
        [HttpGet]
        public IActionResult ShowMeTheCode()
        {
            return Ok("https://github.com.br/erickhsn/CalculaJuros");
        }
    }
}
