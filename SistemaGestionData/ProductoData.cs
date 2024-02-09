using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public class ProductoData
    {
        private static string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        private static List<Producto> productos = new List<Producto>();

        public static List<Producto> ListarProductos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Productos";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int idObtenido = Convert.ToInt32(reader["id"]);
                            string descripcion = reader.GetString(0);
                            double costo = reader.GetFloat(1);
                            double precioVenta = reader.GetFloat(2);
                            //string categoria = reader.GetString(3);
                            short stock = reader.GetInt16(4);
                            int idUsuario = reader.GetInt32(6);

                            Producto productoObtenido = new Producto(idObtenido, descripcion, costo, precioVenta, stock, idUsuario);

                            productos.Add(productoObtenido);
                        }
                        return productos;
                    }
                    throw new Exception("No se encontraron registros");
                }
            }
        }

        public static Producto ObtenerProductoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Productos WHERE Id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string descripcion = reader.GetString(0);
                    double costo = reader.GetFloat(1);
                    double precioVenta = reader.GetFloat(2);
                    //string categoria = reader.GetString(3);
                    short stock = reader.GetInt16(4);
                    int idUsuario = reader.GetInt32(6);

                    Producto productoObtenido = new Producto(idObtenido, descripcion, costo, precioVenta, stock, idUsuario);

                    return productoObtenido;
                }
                throw new Exception("Id no encontrado");
                connection.Close();
            }
        }

        public static bool AgregarProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Productos (Descripcion, Costo, PrecioVenta, Stock, IdUsuario) VALUES(@descripcion, @costo, @precioVenta, @stock, @idUsuario) ";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("descripcion", producto.Descripcion);
                comando.Parameters.AddWithValue("costo", producto.Costo);
                comando.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("stock", producto.Stock);
                comando.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                return comando.ExecuteNonQuery() > 0;
            }

        }

        public static bool BorrarUsuarioPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Productos WHERE Id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        public static bool ActualizaProductoPorId(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Productos SET Descripcion = @descripcion, Costo = @costo, PrecioVenta = @precioVenta, Stock = @stock, IdUsuario = @idUsuario WHERE id = @id";
                connection.Open();
                SqlCommand comando = new SqlCommand(query, connection);
                comando.Parameters.AddWithValue("id", id);
                comando.Parameters.AddWithValue("descripcion", producto.Descripcion);
                comando.Parameters.AddWithValue("costo", producto.Costo);
                comando.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("stock", producto.Stock);
                comando.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}
