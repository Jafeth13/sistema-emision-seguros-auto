using SistemaEmisionSegurosAuto.Domain.Entidades;

namespace SistemaEmisionSegurosAuto.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ObtenerTodosAsync();

        Task<Cliente?> ObtenerPorIdAsync(int id);

        Task<Cliente> CrearAsync(Cliente cliente);
    }
}