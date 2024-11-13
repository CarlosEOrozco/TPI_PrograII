using WebApiFcturacionTPI.Models;

namespace WebApiFcturacionTPI.Repositories
{
    public interface IArticuloRepository
    {
        List<Articulo> GetAll();
        List<Articulo> GetById(int id);

        bool Save(Articulo articulo);
        bool Delete(int id);
        bool Update(int id, Articulo articulo);
    }
}
