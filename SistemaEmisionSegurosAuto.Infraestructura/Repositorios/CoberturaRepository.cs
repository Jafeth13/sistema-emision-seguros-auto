using Microsoft.EntityFrameworkCore;
using SistemaEmisionSegurosAuto.Data;
using SistemaEmisionSegurosAuto.Entidades;
using SistemaEmisionSegurosAuto.Interfaces;

namespace SistemaEmisionSegurosAuto.Repositorios
{
    public class CoberturaRepository : ICoberturaRepository
    {
        private readonly ApplicationDbContext _context;

        public CoberturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cobertura>> ObtenerTodosAsync()
        {
            return await _context.Coberturas
                .Where(x => x.Activo)
                .ToListAsync();
        }

        public async Task<Cobertura?> ObtenerPorIdAsync(int id)
        {
            return await _context.Coberturas.FindAsync(id);
        }

        public async Task<Cobertura> CrearAsync(Cobertura cobertura)
        {
            _context.Coberturas.Add(cobertura);

            await _context.SaveChangesAsync();

            return cobertura;
        }

        public async Task<Cobertura?> ActualizarAsync(Cobertura cobertura)
        {
            var existente = await _context.Coberturas.FindAsync(cobertura.Id);

            if (existente == null)
                return null;

            existente.Nombre = cobertura.Nombre;
            existente.MontoCobertura = cobertura.MontoCobertura;

            await _context.SaveChangesAsync();

            return existente;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var cobertura = await _context.Coberturas
                .FirstOrDefaultAsync(x => x.Id == id);

            if (cobertura == null)
                return false;

            cobertura.Activo = false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}