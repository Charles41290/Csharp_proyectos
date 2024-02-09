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
        public static List<Usuario> GetAllUsers()
        {
            return UsuarioData.ListarUsuarios();
        }

        public static Usuario GetUserById(int id)
        {
            return UsuarioData.ObtenerUsuarioPorId(id);
        }

        public static bool CreateUser(Usuario usuario)
        {
            return UsuarioData.AgregarUsuario(usuario);
        }

        public static bool DeleteUserById(int id)
        {
            return UsuarioData.BorrarUsuarioPorId(id);
        }

        public static bool UpdateUserById(int id, Usuario usuario)
        {
            return UsuarioData.ActualizarUsuarioPorId(id, usuario);
        }
    }
}
