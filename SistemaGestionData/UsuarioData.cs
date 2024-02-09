using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    public class UsuarioData
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        private static List<Usuario> usuarios = new List<Usuario>();

        public static List<Usuario> ListarUsuarios()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuarios";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int idObtenido = Convert.ToInt32(reader["id"]);
                            string nombre = reader.GetString(0);
                            string apellido = reader.GetString(1);
                            string nombreUsuario = reader.GetString(2);
                            string password = reader.GetString(3);
                            string mail = reader.GetString(4);

                            Usuario usuarioObtenido = new Usuario(idObtenido, nombre, apellido, nombreUsuario, password, mail);
                            usuarios.Add(usuarioObtenido);
                        }
                        return usuarios;
                    }
                    throw new Exception("No se encontraron usuarios");
                }
            }
        }


        public static Usuario ObtenerUsuarioPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuarios WHERE Id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string nombre = reader.GetString(0);
                    string apellido = reader.GetString(1);
                    string nombreUsuario = reader.GetString(2);
                    string password = reader.GetString(3);
                    string mail = reader.GetString(4);

                    Usuario usuarioObtenido = new Usuario(idObtenido, nombre, apellido, nombreUsuario, password, mail);
                    return usuarioObtenido;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public static bool AgregarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Usuarios (Nombre, Apellido, NombreUsuario, Contrasenia, Mail) VALUES (@nombre, @apellido, @nombreUsuario, @contrasenia, @mail)";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("contrasenia", usuario.Contrasenia);
                comando.Parameters.AddWithValue("mail", usuario.Mail);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool BorrarUsuarioPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Usuarios WHERE Id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool ActualizarUsuarioPorId(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuarios SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreUsuario, Contrasenia = @contrasenia, Mail = @mail WHERE Id = @id ";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("contrasenia", usuario.Contrasenia);
                comando.Parameters.AddWithValue("mail", usuario.Mail);

                return comando.ExecuteNonQuery() > 0;
            }

        }
    }
}
