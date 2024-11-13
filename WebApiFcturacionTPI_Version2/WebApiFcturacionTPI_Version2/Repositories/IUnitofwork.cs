using Microsoft.EntityFrameworkCore.Storage;

namespace WebApiFcturacionTPI.Repositories
{
    public interface IUnitofwork
    {
        IFacturasRepository facturas { get;  }
        IDetalleRepository detalles { get;  }

        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
