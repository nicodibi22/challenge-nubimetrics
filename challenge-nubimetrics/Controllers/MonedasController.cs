using challenge_nubimetrics_services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_nubimetrics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonedasController : ControllerBase
    {

        private readonly MonedaService _monedaService;
        public MonedasController(MonedaService monedaService)
        {
            _monedaService = monedaService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<IActionResult> Get(string pais)
        {
            try
            {
                await _monedaService.Procesar();
                return Ok();
            }
            catch (ArgumentException)
            {

                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
