using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;

namespace WebAPISistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosVendidosController : Controller
    {
        [HttpGet]
        public List<ProductoVendido> obtenerListadoProductosVendidos()
        {
            try
            {
                return ProductoVendidoBussines.GetAllProductsSold();
            }
            catch (Exception)
            {

                return new List<ProductoVendido>() {};
            }
        }

        [HttpGet("{id}")]
        public ActionResult<string> obtenerProductoVendidoPorId(int id)
        {
            try
            {
                return ProductoVendidoBussines.GetProductSoldById(id).ToString();
            }
            catch (Exception)
            {

                return BadRequest(new { mensaje = "Id no encontrado", status = 404 });
            }
        }

    }
}
