using challenge_nubimetrics_services.DTOs;
using challenge_nubimetrics_services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge_nubimetrics.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {

        private readonly UsuarioService _usuarioService;
        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody]UsuarioDTO usuario)
        {
            try
            {
                int result = await _usuarioService.Add(usuario);
                var uri = new Uri(Request.GetEncodedUrl() + "/" + result);
                return Created(uri, new { id = result });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioDTO usuario)
        {
            try
            {
                usuario.Id = id;
                await _usuarioService.Update(usuario);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _usuarioService.GetById(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _usuarioService.GetAsync());
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _usuarioService.Remove(id);
                return Accepted();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
