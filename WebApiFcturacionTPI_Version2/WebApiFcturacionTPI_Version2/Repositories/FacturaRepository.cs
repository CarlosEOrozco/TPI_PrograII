using WebApiFcturacionTPI.Models;

namespace WebApiFcturacionTPI.Repositories
{
    public class FacturaRepository : IFacturasRepository
    {
        private readonly facturacionContext _context;

        public FacturaRepository(facturacionContext context)
        {
            _context = context;
        }

        public bool Delete(int id, string motivobaja)
        {
            var factura = _context.Facturas.Find(id);
            if(factura != null)
            {
               factura.Motivobaja = motivobaja;
                _context.Facturas.Update(factura);
                return _context.SaveChanges() == 1;
            }
            return false;
        }

        public List<Factura> GetAll()
        {
            return _context.Facturas.ToList();
        }

        public List<Cliente> GetAllClientes()
        {
            return _context.Clientes.ToList();
        }

        public List<FormasPago> GetAllFormas()
        {
            return _context.FormasPagos.ToList();
        }

        public bool Save(Factura factura)
        {
            _context.Facturas.Add(factura);
            return true;
        }

       
    }
}
