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
    [Route("api/monedas")]
    public class MonedasController : ControllerBase
    {

        private readonly MonedaService _monedaService;
        public MonedasController(MonedaService monedaService)
        {
            _monedaService = monedaService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<IActionResult> Procesar()
        {
            try
            {
                await _monedaService.Procesar();
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message});
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
            
        }
    }
}
