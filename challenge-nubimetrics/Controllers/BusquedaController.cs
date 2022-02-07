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
    [Route("api/busqueda")]
    public class BusquedaController : ControllerBase
    {

        private readonly BusquedaService _busquedaService;
        public BusquedaController(BusquedaService busquedaService)
        {
            _busquedaService = busquedaService;
        }

        [HttpGet("{termino}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<IActionResult> Get(string termino)
        {
            try
            {
                return Ok(await _busquedaService.Buscar(termino));
            }
            catch (ArgumentException)
            {

                return NotFound();
            }
            
        }
    }
}
