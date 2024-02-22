using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;

namespace WebAPISistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        [HttpGet]
        public List<Usuario> ObtenerListadoDeUsuarios()
        {
            return UsuarioBussines.GetAllUsers();
        }
    } 
}
