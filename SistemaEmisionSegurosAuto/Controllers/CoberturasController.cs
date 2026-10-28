using Microsoft.AspNetCore.Mvc;
using SistemaEmisionSegurosAuto.DTOs;
using SistemaEmisionSegurosAuto.Exceptions;
using SistemaEmisionSegurosAuto.Interfaces;

namespace SistemaEmisionSegurosAuto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoberturasController : ControllerBase
    {
        private readonly ICoberturaService _service;

        public CoberturasController(ICoberturaService service)
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
            var cobertura = await _service.ObtenerPorIdAsync(id);

            if (cobertura == null)
            {
                throw new NotFoundException(
                    "Cobertura no encontrada");
            }

            return Ok(cobertura);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CoberturaDto dto)
        {
            var cobertura = await _service.CrearAsync(dto);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = cobertura.Id },
                cobertura);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(
            int id,
            CoberturaDto dto)
        {
            var cobertura = await _service.ActualizarAsync(id, dto);

            if (cobertura == null)
            {
                throw new NotFoundException(
                    "Cobertura no encontrada");
            }

            return Ok(cobertura);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _service.EliminarAsync(id);

            if (!eliminado)
            {
                throw new NotFoundException(
                    "Cobertura no encontrada");
            }

            return NoContent();
        }
    }
}