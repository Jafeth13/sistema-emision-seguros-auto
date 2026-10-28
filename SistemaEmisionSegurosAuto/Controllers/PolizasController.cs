using Microsoft.AspNetCore.Mvc;
using SistemaEmisionSegurosAuto.DTOs;
using SistemaEmisionSegurosAuto.Exceptions;
using SistemaEmisionSegurosAuto.Interfaces;

namespace SistemaEmisionSegurosAuto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolizasController : ControllerBase
    {
        private readonly IPolizaService _service;

        public PolizasController(IPolizaService service)
        {
            _service = service;
        }

        [HttpPost("emitir")]
        public async Task<IActionResult> Emitir(
            EmitirPolizaDto dto)
        {
            var resultado =
                await _service.EmitirAsync(dto);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = resultado.Id },
                resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            return Ok(
                await _service.ObtenerTodasAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(
            int id)
        {
            var poliza =
                await _service.ObtenerPorIdAsync(id);

            if (poliza == null)
            {
                throw new NotFoundException(
                    "Póliza no encontrada");
            }

            return Ok(poliza);
        }
    }
}