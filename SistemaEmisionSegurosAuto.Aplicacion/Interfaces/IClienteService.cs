using SistemaEmisionSegurosAuto.DTOs;
using SistemaEmisionSegurosAuto.Domain.Entidades;

namespace SistemaEmisionSegurosAuto.Interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> ObtenerTodosAsync();

        Task<Cliente?> ObtenerPorIdAsync(int id);

        Task<Cliente> CrearAsync(ClienteDto dto);
    }
}