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
    public class PaisesController : ControllerBase
    {

        private readonly PaisesService _paisesService;
        public PaisesController(PaisesService paisesService)
        {
            _paisesService = paisesService;
        }

        [HttpGet("{pais}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<IActionResult> Get(string pais)
        {
            try
            {
                return Ok(await _paisesService.GetPaisInfo(pais));
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
