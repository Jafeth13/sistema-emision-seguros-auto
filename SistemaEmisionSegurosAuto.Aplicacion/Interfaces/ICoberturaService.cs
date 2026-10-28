using SistemaEmisionSegurosAuto.DTOs;
using SistemaEmisionSegurosAuto.Domain.Entidades;
using SistemaEmisionSegurosAuto.Entidades;

namespace SistemaEmisionSegurosAuto.Interfaces
{
    public interface ICoberturaService
    {
        Task<List<Cobertura>> ObtenerTodosAsync();

        Task<Cobertura?> ObtenerPorIdAsync(int id);

        Task<Cobertura> CrearAsync(CoberturaDto dto);

        Task<Cobertura?> ActualizarAsync(int id, CoberturaDto dto);

        Task<bool> EliminarAsync(int id);
    }
}