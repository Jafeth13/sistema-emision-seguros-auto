using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SistemaEmisionSegurosAuto.Data;
using SistemaEmisionSegurosAuto.Domain.Entidades;
using SistemaEmisionSegurosAuto.Entidades;
using SistemaEmisionSegurosAuto.Interfaces;

namespace SistemaEmisionSegurosAuto.Repositorios
{
    public class PolizaRepository : IPolizaRepository
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction? _transaction;

        public PolizaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction =
                await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public async Task<Cliente?> ObtenerClienteAsync(
            int clienteId)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(x => x.Id == clienteId);
        }

        public async Task<List<Cobertura>> ObtenerCoberturasAsync(
            List<int> coberturasIds)
        {
            return await _context.Coberturas
                .Where(x => coberturasIds.Contains(x.Id))
                .ToListAsync();
        }

        public async Task<Vehiculo> CrearVehiculoAsync(
            Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);

            await _context.SaveChangesAsync();

            return vehiculo;
        }

        public async Task<Poliza> CrearAsync(
            Poliza poliza)
        {
            _context.Polizas.Add(poliza);

            await _context.SaveChangesAsync();

            return poliza;
        }

        public async Task GuardarPolizaCoberturasAsync(
            List<PolizaCobertura> polizaCoberturas)
        {
            _context.PolizaCoberturas.AddRange(polizaCoberturas);

            await _context.SaveChangesAsync();
        }

        public async Task<Poliza?> ObtenerPorIdAsync(
        int id)
        {
            return await _context.Polizas
                .Include(x => x.Cliente)
                .Include(x => x.Vehiculo)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Poliza>> ObtenerTodasAsync()
        {
            return await _context.Polizas
                .Include(x => x.Cliente)
                .Include(x => x.Vehiculo)
                .ToListAsync();
        }
    }
}