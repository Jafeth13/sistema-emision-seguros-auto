using SistemaEmisionSegurosAuto.DTOs;
using SistemaEmisionSegurosAuto.Domain.Entidades;
using SistemaEmisionSegurosAuto.Entidades;

namespace SistemaEmisionSegurosAuto.Interfaces
{
    public interface IPolizaService
    {
        Task<PolizaResponseDto> EmitirAsync(
            EmitirPolizaDto dto);

        Task<Poliza?> ObtenerPorIdAsync(
            int id);

        Task<List<Poliza>> ObtenerTodasAsync();
    }
}