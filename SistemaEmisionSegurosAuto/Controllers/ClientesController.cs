using Microsoft.AspNetCore.Mvc;
using SistemaEmisionSegurosAuto.DTOs;
using SistemaEmisionSegurosAuto.Exceptions;
using SistemaEmisionSegurosAuto.Interfaces;

namespace SistemaEmisionSegurosAuto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(await _service.ObtenerTodosAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var cliente = await _service.ObtenerPorIdAsync(id);

            if (cliente == null)
            {
                throw new NotFoundException(
                    "Cliente no encontrado");
            }

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ClienteDto dto)
        {
            var cliente = await _service.CrearAsync(dto);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = cliente.Id },
                cliente);
        }
    }
}