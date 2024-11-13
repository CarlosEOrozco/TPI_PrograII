using WebApiFcturacionTPI.Models;

namespace WebApiFcturacionTPI.Repositories
{
    public interface IFacturasRepository
    {
        List<Factura> GetAll();

        bool Save(Factura factura);

        bool Delete(int id, string motivobaja);
        List<FormasPago> GetAllFormas();

        List<Cliente> GetAllClientes();
    }
}
