using SistemaEmisionSegurosAuto.Domain.Entidades;
using SistemaEmisionSegurosAuto.Entidades;

namespace SistemaEmisionSegurosAuto.Interfaces
{
    public interface ICoberturaRepository
    {
        Task<List<Cobertura>> ObtenerTodosAsync();

        Task<Cobertura?> ObtenerPorIdAsync(int id);

        Task<Cobertura> CrearAsync(Cobertura cobertura);

        Task<Cobertura?> ActualizarAsync(Cobertura cobertura);

        Task<bool> EliminarAsync(int id);
    }
}