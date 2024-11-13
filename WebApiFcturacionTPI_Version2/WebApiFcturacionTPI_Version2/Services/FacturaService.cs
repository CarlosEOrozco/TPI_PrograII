using WebApiFcturacionTPI.Models;
using WebApiFcturacionTPI.Repositories;

namespace WebApiFcturacionTPI.Services
{
    public class FacturaService
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IFacturasRepository _repository;
        private readonly IDetalleRepository _repositoryDetalle;

        public FacturaService(IUnitofwork unitOfWork, IFacturasRepository repository, IDetalleRepository repositoryDetalle)
        {

            _unitOfWork = unitOfWork;
            _repository = repository;
            _repositoryDetalle = repositoryDetalle;
        }

        public async Task CrearFacturaConDetalles(Factura nuevaFactura, List<Detallefactura> detalles)
        {

            _unitOfWork.facturas.Save(nuevaFactura);
            await _unitOfWork.SaveChangesAsync(); // Asegura que Nrofactura se genera

            // Asocia cada detalle con el Nrofactura de la factura guardada
            foreach (var detalle in detalles)
            {
                detalle.Nrofactura = nuevaFactura.Nrofactura;
                _unitOfWork.detalles.Save(detalle);
            }

            // Guarda los cambios para los detalles
            await _unitOfWork.SaveChangesAsync();

        }

        public List<Factura> GetAll()
        {
            return _repository.GetAll();
        }
        public bool Delete(int id, string motivobaja)
        {
            return _repository.Delete(id, motivobaja);
        }
        public List<FormasPago> GetAllFormas()
        {
            return _repository.GetAllFormas();
        }

        public List<Cliente> GetAllClientes()
        {
            return _repository.GetAllClientes();
        }

        public List<Detallefactura> GetDetallesById(int id)
        {
            return _repositoryDetalle.GetByFactura(id);   
        }

        public List<Detallefactura> GetAllDetalles()
        {
            return _repositoryDetalle.GetAllDetalles();
        }

    }
}
