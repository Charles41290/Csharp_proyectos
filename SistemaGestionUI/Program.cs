using SistemaGestionBussines;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
				//List<Producto> productos = ProductoBussines.GetAllProductos();
				//foreach(Producto producto in productos)
				//{
				//	Console.WriteLine(producto);
				//}

				//Venta ventaAAgregar = new Venta("Todo flama", 2);
				//if(VentaData.AgregarVenta(ventaAAgregar))
				//{
				//	Console.WriteLine("Venta Agregada");
				//}

				//List<Usuario> usuarios = UsuarioBussines.GetAllUsers();
				//foreach(Usuario usuario in usuarios)
				//{
				//	Console.WriteLine(usuario);
				//}


				List<ProductoVendido> productos = ProductoVendidoBussines.GetAllProductsSold();
				foreach (var product in productos)
				{
					Console.WriteLine(product);
				}

			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.ToString);
			}
        }
    }
}
