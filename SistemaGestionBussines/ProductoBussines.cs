using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using SistemaGestionData;

namespace SistemaGestionBussines
{
    public static class ProductoBussines
    {
        public static List<Producto> GetAllProductos()
        {
            return ProductoData.ListarProductos();
        }

        public static Producto GetProductById(int id)
        {
            return ProductoData.ObtenerProductoPorId(id);
        }

        public static bool CreateProduct(Producto producto)
        {
            return ProductoData.AgregarProducto(producto);
        }

        public static bool DeleteProductById(int id) 
        {
            return ProductoData.BorrarUsuarioPorId(id);
        }

        public static bool UpdateProductById(int id, Producto producto)
        {
            return ProductoData.ActualizaProductoPorId(id, producto);
        }
    }
}
