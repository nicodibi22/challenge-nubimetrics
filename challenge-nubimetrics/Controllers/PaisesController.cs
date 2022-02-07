using challenge_nubimetrics_services.Services;
using challenge_nubimetrics_services.Utils;
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

        private readonly PaisService _paisesService;
        public PaisesController(PaisService paisesService)
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
            catch (UnauthorizedException)
            {
                return Unauthorized(new {message = "error 401 unauthorized de http" });
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            
        }
    }
}
