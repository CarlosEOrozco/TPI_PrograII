using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFcturacionTPI.Models;
using WebApiFcturacionTPI.Services;

namespace WebApiFcturacionTPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IarticuloService _service;

        public ArticulosController(IarticuloService service)
        {
            _service = service;
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

        [HttpGet("/getby{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_service.GetById(id));

            }
            catch (Exception)
            {
                return StatusCode(500, "error interno");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Articulo articulo)
        {
            try
            {
                if (Validar(articulo) == true)
                {
                    _service.Save(articulo);
                    return Ok("articulo ingresado con exito");
                }
                else
                    return BadRequest("datos incorrectos");
            }
            catch(Exception)
            {
                return StatusCode(500, "error interno");
            }
        }


        [HttpPut(("{id}"))]
        public IActionResult Put(int id, [FromBody]Articulo articulo)
        {
            try
            {
                if (_service.Update(id, articulo))
                {
                    return Ok("articulo actualizado");
                }
                else
                    return BadRequest("datos invalidos");
            }
            catch(Exception)
            {
                return StatusCode(500, "error interno");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_service.Delete(id))
                {
                    return Ok("articulo eliminado");
                }
                else return NotFound("articulo no encontrado");
            }
            catch(Exception)
            {
                return StatusCode(500, "error interno");
            }
        }

        private bool Validar(Articulo articulo)
        {
            var validados = true;

            if (string.IsNullOrEmpty(articulo.Nombre))
            {
                return validados = false;
            }
            else if (articulo.Precio == 0)
            {
                return validados = false;
            }
            return validados;
        }
    }
}
