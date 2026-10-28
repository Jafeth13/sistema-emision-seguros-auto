using SistemaEmisionSegurosAuto.Domain.Entidades;
using SistemaEmisionSegurosAuto.Entidades;

public interface IPolizaRepository
{
    Task<Poliza> CrearAsync(Poliza poliza);

    Task GuardarPolizaCoberturasAsync(
        List<PolizaCobertura> polizaCoberturas);

    Task<Cliente?> ObtenerClienteAsync(int clienteId);

    Task<List<Cobertura>> ObtenerCoberturasAsync(
        List<int> coberturasIds);

    Task<Vehiculo> CrearVehiculoAsync(
        Vehiculo vehiculo);

    Task BeginTransactionAsync();

    Task CommitTransactionAsync();

    Task RollbackTransactionAsync();

    Task<Poliza?> ObtenerPorIdAsync(int id);

    Task<List<Poliza>> ObtenerTodasAsync();

}