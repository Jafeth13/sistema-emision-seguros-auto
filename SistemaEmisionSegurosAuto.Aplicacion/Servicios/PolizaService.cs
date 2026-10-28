using SistemaEmisionSegurosAuto.DTOs;
using SistemaEmisionSegurosAuto.Domain.Entidades;
using SistemaEmisionSegurosAuto.Interfaces;
using SistemaEmisionSegurosAuto.Exceptions;
using SistemaEmisionSegurosAuto.Entidades;
namespace SistemaEmisionSegurosAuto.Servicios
{
    public class PolizaService : IPolizaService
    {
        private readonly IPolizaRepository _repository;

        public PolizaService(IPolizaRepository repository)
        {
            _repository = repository;
        }


        public async Task<PolizaResponseDto> EmitirAsync(
    EmitirPolizaDto dto)
        {
            await _repository.BeginTransactionAsync();

            try
            {
                if (dto.CoberturasIds == null ||
                    !dto.CoberturasIds.Any())
                {
                    throw new BusinessException(
                        "Debe seleccionar al menos una cobertura");
                }

                var cliente = await _repository
                    .ObtenerClienteAsync(dto.ClienteId);

                if (cliente == null)
                {
                    throw new NotFoundException(
                        "Cliente no encontrado");
                }

                var vehiculo = new Vehiculo
                {
                    Placa = dto.Vehiculo.Placa,
                    Marca = dto.Vehiculo.Marca,
                    Modelo = dto.Vehiculo.Modelo,
                    Anio = dto.Vehiculo.Anio,
                    ValorComercial = dto.Vehiculo.ValorComercial
                };

                await _repository.CrearVehiculoAsync(vehiculo);

                var coberturas = await _repository
                    .ObtenerCoberturasAsync(dto.CoberturasIds);

                decimal primaTotal =
                    coberturas.Sum(x => x.MontoCobertura);

                var poliza = new Poliza
                {
                    NumeroPoliza =
                        $"POL-{DateTime.Now:yyyyMMddHHmmss}",

                    FechaEmision = DateTime.Now,

                    PrimaTotal = primaTotal,

                    SumaAsegurada = primaTotal,

                    ClienteId = cliente.Id,

                    VehiculoId = vehiculo.Id
                };

                await _repository.CrearAsync(poliza);

                var relaciones = coberturas
                    .Select(c => new PolizaCobertura
                    {
                        PolizaId = poliza.Id,
                        CoberturaId = c.Id
                    })
                    .ToList();

                await _repository
                    .GuardarPolizaCoberturasAsync(relaciones);

                await _repository.CommitTransactionAsync();

                return new PolizaResponseDto
                {
                    Id = poliza.Id,
                    NumeroPoliza = poliza.NumeroPoliza,
                    PrimaTotal = poliza.PrimaTotal,
                    SumaAsegurada = poliza.SumaAsegurada,
                    FechaEmision = poliza.FechaEmision
                };
            }
            catch
            {
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }
        public async Task<Poliza?> ObtenerPorIdAsync(
    int id)
        {
            return await _repository.ObtenerPorIdAsync(id);
        }

        public async Task<List<Poliza>> ObtenerTodasAsync()
        {
            return await _repository.ObtenerTodasAsync();
        }

    }
 }