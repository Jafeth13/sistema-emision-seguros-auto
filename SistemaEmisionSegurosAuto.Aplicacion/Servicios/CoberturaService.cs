using SistemaEmisionSegurosAuto.DTOs;
using SistemaEmisionSegurosAuto.Domain.Entidades;
using SistemaEmisionSegurosAuto.Interfaces;
using SistemaEmisionSegurosAuto.Entidades;

namespace SistemaEmisionSegurosAuto.Servicios
{
    public class CoberturaService : ICoberturaService
    {
        private readonly ICoberturaRepository _repository;

        public CoberturaService(ICoberturaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Cobertura>> ObtenerTodosAsync()
        {
            return await _repository.ObtenerTodosAsync();
        }

        public async Task<Cobertura?> ObtenerPorIdAsync(int id)
        {
            return await _repository.ObtenerPorIdAsync(id);
        }

        public async Task<Cobertura> CrearAsync(CoberturaDto dto)
        {
            var cobertura = new Cobertura
            {
                Nombre = dto.Nombre,
                MontoCobertura = dto.MontoCobertura
            };

            return await _repository.CrearAsync(cobertura);
        }

        public async Task<Cobertura?> ActualizarAsync(int id, CoberturaDto dto)
        {
            var cobertura = new Cobertura
            {
                Id = id,
                Nombre = dto.Nombre,
                MontoCobertura = dto.MontoCobertura
            };

            return await _repository.ActualizarAsync(cobertura);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repository.EliminarAsync(id);
        }
    }
}