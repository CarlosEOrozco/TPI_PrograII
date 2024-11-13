using WebApiFcturacionTPI.Models;

namespace WebApiFcturacionTPI.Repositories
{
    public class DetalleRepository : IDetalleRepository
    {
        private readonly facturacionContext _context;
        public DetalleRepository(facturacionContext context)
        {
            _context = context;
        }

        public List<Detallefactura> GetAllDetalles()
        {
            return _context.Detallefacturas.ToList();
        }

        public List<Detallefactura> GetByFactura(int nroFactura)
        {
            var detalles = _context.Detallefacturas
                           .Where(d => d.Nrofactura == nroFactura)
                           .ToList();
            return detalles;

        }

        public bool Save(Detallefactura detallefactura)
        {
            _context.Detallefacturas.Add(detallefactura);
            return true;
        }
    }
}
