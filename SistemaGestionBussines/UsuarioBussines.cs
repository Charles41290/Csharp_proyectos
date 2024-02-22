using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussines
{
    public class UsuarioBussines
    {

        // anteriormente todos los siguientes métodos eran estáticos
        public List<Usuario> GetAllUsers()
        {
            return UsuarioData.ListarUsuarios();
        }

        public Usuario GetUserById(int id)
        {
            return UsuarioData.ObtenerUsuarioPorId(id);
        }

        public bool CreateUser(Usuario usuario)
        {
            return UsuarioData.AgregarUsuario(usuario);
        }

        public bool DeleteUserById(int id)
        {
            return UsuarioData.BorrarUsuarioPorId(id);
        }

        public bool UpdateUserById(int id, Usuario usuario)
        {
            return UsuarioData.ActualizarUsuarioPorId(id, usuario);
        }
    }
}
