using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFcturacionTPI.Models;
using WebApiFcturacionTPI.Services;

namespace WebApiFcturacionTPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _service;

        public FacturaController(FacturaService facturaService)
        {
            _service = facturaService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearFactura([FromBody] Factura factura)
        {
            var nuevaFactura = new Factura
            {
                // Mapea los datos del DTO a Factura
                Nrofactura = factura.Nrofactura,
                Fecha = factura.Fecha,
                Formapago = factura.Formapago,
                Cliente = factura.Cliente
            };

            var detalles = factura.Detalles.Select(d => new Detallefactura
            {
                Idarticulo = d.Idarticulo,
                Cantidad = d.Cantidad
            }).ToList();

            await _service.CrearFacturaConDetalles(nuevaFactura, detalles);

            return Ok();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno");
            }
        }
        [HttpGet("formas")]
        public IActionResult GetFormas()
        {
            try
            {
                return Ok(_service.GetAllFormas());
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno");
            }
        }

        [HttpGet("clientes")]
        public IActionResult GetClientes()
        {
            try
            {
                return Ok(_service.GetAllClientes());
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno");
            }
        }

        [HttpGet("DetalleFactura/{id}")]
        public IActionResult GetDetalleByFactura(int id)
        {
            try
            {
                return Ok(_service.GetDetallesById(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno");
            }
        }

        [HttpGet("DetallesFactura")]
        public IActionResult GetAllDetalles()
        {
            try
            {
                return Ok(_service.GetAllDetalles());
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno");
            }
        }



        [HttpDelete("{id}, {motivoBaja}")]
        public IActionResult Delele(int id,  string motivobaja)
        {
            try
            {
                if (_service.Delete(id, motivobaja))
                    return Ok("factura dada de baja");
                else
                    return NotFound("factura no encontrada");
            }
            catch(Exception)
            {
                return StatusCode(500, "error interno");
            }
        }
    }
}
