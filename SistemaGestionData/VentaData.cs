using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class VentaData
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        private static List<Venta> ventas = new List<Venta>();

        public static List<Venta> ListarVentas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Ventas";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int idObtenido = Convert.ToInt32(reader["Id"]);
                            string comentarios = reader["Comentarios"].ToString();
                            int idUsuario = Convert.ToInt32(reader["IdUsuario"]);
                            Venta ventaObtenida = new Venta(idObtenido, comentarios, idUsuario);
                            ventas.Add(ventaObtenida);
                        }
                        return ventas;
                    }
                    throw new Exception("No se encontraron registros");
                }
            }
        }

        public static Venta ObtenerVentaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Ventas WHERE Id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("Id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["Id"]);
                    string comentarios = reader["Comentarios"].ToString();
                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    Venta ventaObtenida = new Venta(idObtenido, comentarios, idUsuario);
                    return ventaObtenida;
                }
                throw new Exception("No se encontró el Id buscado");
            }
        }

        public static bool AgregarVenta(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Ventas (Comentarios, IdUsuario) VALUES(@comentarios, @idUsuario) ";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("comentarios", venta.Comentarios);
                comando.Parameters.AddWithValue("idUsuario", venta.IdUsuario);
                return comando.ExecuteNonQuery() > 0;
            }

        }

        public static bool BorrarVentaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Ventas WHERE Id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool ActualizarVentaPorId(int id, Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Ventas SET Comentarios = @comentarios, IdUsuario = @idUsuario WHERE Id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("comentarios", venta.Comentarios);
                comando.Parameters.AddWithValue("idUsuario", venta.IdUsuario);
                Console.WriteLine(comando.ExecuteNonQuery());
                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}
