using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;
using System.Data.SqlClient;

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
                return new List<Producto>() {};
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
    }
}

