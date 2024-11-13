using WebApiFcturacionTPI.Models;
using WebApiFcturacionTPI.Repositories;

namespace WebApiFcturacionTPI.Services
{
    public class ArticuloManager : IarticuloService
    {
        private IArticuloRepository _repository;

        public ArticuloManager(IArticuloRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<Articulo> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Articulo> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Save(Articulo articulo)
        {
            return _repository.Save(articulo);
        }

        public bool Update(int id, Articulo articulo)
        {
           return _repository.Update(id, articulo);
        }
    }
}
