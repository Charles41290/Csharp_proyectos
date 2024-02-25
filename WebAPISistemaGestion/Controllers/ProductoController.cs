using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;
using DTOs;

namespace WebAPISistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private ProductoBussines productoService;

        // el param productService se inyecta como dependencia en Program.cs
        public ProductoController(ProductoBussines productoService)
        {
            this.productoService = productoService;
        }


        [HttpGet]
        public List<Producto> ObtenerListadoDeProductos()
        {
            try
            {
                return this.productoService.GetAllProductos();
            }
            catch (Exception)
            {
                // retorno una lista vacía 
                return new List<Producto>() { };
            }

        }

        [HttpGet("{id}")]
        public ActionResult<string> obtenerProductoPorId(int id)
        {
            try
            {
                return this.productoService.GetProductById(id).ToString();
            }
            catch (Exception)
            {

                return BadRequest(new { mensaje = "Id no encontrado", status = 404 });
            }
        }

        [HttpPost]
        public IActionResult AgregarProducto([FromBody] ProductoDTO producto)
        {
            if (this.productoService.CreateProduct(producto))
            {
                return base.Ok(new { mensaje = "Producto agregado", producto });
            }
            else
            {
                return base.Conflict(new { mensaje = "El producto no pudo ser agregado" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult BorradProducto(int id)
        {
            if (id > 0)
            {
                if (this.productoService.DeleteProductById(id))
                {
                    return base.Ok(new { mensaje = "Producto eliminado", status = 200 });
                }
                else
                {
                    return base.Conflict(new { mensaje = "No se pudo eliminar el producto" });
                }
            }
            return base.BadRequest(new { mensaje = "Id inválido", status = 404 });
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarProductoPorId(int id, Producto producto) 
        {
            if (id > 0)
            {
                if (this.productoService.UpdateProductById(id, producto))
                {
                    return base.Ok(new { mensaje = "Producto actualizado", status = 200 });
                }
                else
                {
                    return base.Conflict(new { mensaje = "No se pudo actualizar el producto" });
                }
            }
            return base.BadRequest(new { mensaje = "Id inválido", status = 404 });

        }
    }
}

