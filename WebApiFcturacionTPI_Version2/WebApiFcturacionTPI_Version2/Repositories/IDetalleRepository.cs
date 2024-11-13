using WebApiFcturacionTPI.Models;

namespace WebApiFcturacionTPI.Repositories
{
    public interface IDetalleRepository
    {
        bool Save(Detallefactura detallefactura);
        List<Detallefactura> GetByFactura(int nroFactura);
        List<Detallefactura> GetAllDetalles();
    }
}
