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

        private readonly IPaisesService _paisesService;
        public PaisesController(IPaisesService paisesService)
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

            return null;
        }
    }
}
