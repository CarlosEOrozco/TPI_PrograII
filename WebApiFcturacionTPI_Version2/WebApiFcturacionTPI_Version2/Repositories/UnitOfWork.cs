
using Microsoft.EntityFrameworkCore.Storage;
using WebApiFcturacionTPI.Models;

namespace WebApiFcturacionTPI.Repositories
{
    public class UnitOfWork : IUnitofwork
    {
        private readonly facturacionContext _context;
        public IFacturasRepository facturas { get; }
        public IDetalleRepository detalles { get; }

        public UnitOfWork(facturacionContext context)
        {
            _context = context;
            facturas = new FacturaRepository(_context);
            detalles = new DetalleRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var result = await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return result;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
    
}
