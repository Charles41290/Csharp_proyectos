using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;

namespace WebAPISistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : Controller
    {
        // no es necesario ya qu los metodo de la clase VentasBussines son estáticos
        // private VentaBussines ventaService;

        [HttpGet]
        public List<Venta> ObtenerListadoDeVentas()
        {
            try
            {
                return VentaBussines.GetAllSales();
            }
            catch (Exception)
            {
                // retorna una lista vacía en caso ocurra la excepcion del VentaData
                return new List<Venta>() { };
            }
        }

        [HttpGet("{id}")]
        public ActionResult<string> ObtenerVentaPorId(int id)
        {
            try
            {
                return VentaBussines.GetSaleById(id).ToString();
            }
            catch (Exception)
            {

                return BadRequest(new { mensaje = "Id no encontrado", status = 404 });
            }
        }

        [HttpPost]
        public ActionResult<string> AgregarVenta([FromBody] Venta venta)
        {
            if (VentaBussines.CreateSale(venta))
            {
                return base.Ok(new { mensaje = "Venta agregada" });
            }
            else
            {
                return base.Conflict(new { mensaje = "La venta no pudo ser agregada" });
            }
        }
    }
}
