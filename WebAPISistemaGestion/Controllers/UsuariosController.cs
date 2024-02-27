using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;

namespace WebAPISistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private UsuarioBussines usuarioService;

        // el param usuarioService se inyecta como dependencia en Program.cs
        public UsuariosController(UsuarioBussines usuarioService) 
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public List<Usuario> ObtenerListadoDeUsuarios()
        {
            try
            {
                return this.usuarioService.GetAllUsers();
            }
            catch (Exception)
            {
                // retorna una lista vacía
                return new List<Usuario>() {};
            }
            
        }

        [HttpGet("{id}")]
        //public string ObtenerUsuarioPorId(int id)
        public ActionResult<string> ObtenerUsuarioPorId(int id)
        {
            try
            {
                return this.usuarioService.GetUserById(id).ToString();
            }
            catch (Exception)
            {

                return BadRequest(new {mensaje = "Id no encontrado", status = 404});
            }
        }

        [HttpPut("{id}")]
        public ActionResult<string> ActualizarUsuarioPorId(int id, Usuario usuario)
        {
            if (id > 0)
            {
                if (this.usuarioService.UpdateUserById(id, usuario))
                {
                    return base.Ok(new {mensaje = "Usuario actualizado", status = 200 });
                }
                else
                {
                    return base.Conflict(new { mensaje = "No se pudo actualizar el usuario" });
                }
            }
            return base.BadRequest(new { mensaje = "Id inválido", status = 404 });
        }


    }

    


}
