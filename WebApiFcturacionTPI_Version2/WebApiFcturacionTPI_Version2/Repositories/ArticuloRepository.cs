using WebApiFcturacionTPI.Models;

namespace WebApiFcturacionTPI.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly facturacionContext _context;

        public ArticuloRepository(facturacionContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var articulo = _context.Articulos.Find(id);
            if (articulo != null)
            {
                articulo.Estado = "NH";
               _context.Articulos.Update(articulo);
               
              return _context.SaveChanges() == 1;
                
            }
            return false;
        }

        public List<Articulo> GetAll()
        {
            return _context.Articulos.ToList();
        }

        public List<Articulo> GetById(int id)
        {
            _context.Articulos.Find(id);
            return _context.Articulos.Where(a => a.Idarticulo == id).ToList();
        }

        public bool Save(Articulo articulo)
        {
            if(articulo != null)
            {
                _context.Articulos.Add(articulo);
                return _context.SaveChanges() == 1;
            }
            return false;
        }

        public bool Update(int id, Articulo articulo)
        {
            var entity = _context.Articulos.Find(id);
            if(entity == null) return false;
                entity.Idarticulo = articulo.Idarticulo;
                entity.Nombre = articulo.Nombre;
                entity.Precio = articulo.Precio;
            _context.Articulos.Update(entity);
            return _context.SaveChanges() == 1;
           
        }
    }
}
