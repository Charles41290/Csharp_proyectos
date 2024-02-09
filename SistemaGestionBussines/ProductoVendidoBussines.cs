using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussines
{
    public class ProductoVendidoBussines
    {
        public static List<ProductoVendido> GetAllProductsSold()
        {
            return ProductoVendidoData.ListarProductosVendidos();
        }

        public static ProductoVendido GetProductSoldById(int id)
        {
            return ProductoVendidoData.ObtenerProductoVendidoPorId(id);
        }

        public static bool CreateProductSold(ProductoVendido productoVendido)
        {
            return ProductoVendidoData.AgregarProductoVendido(productoVendido);
        }

        public static bool DeleteProductSoldById(int id)
        {
            return ProductoVendidoData.BorrarProductoVendidoPorId(id);
        }

        public static bool UpdateProductSoldById(int id,ProductoVendido productoVendido)
        {
            return ProductoVendidoData.ActualizarProductoVendidoPorId(id, productoVendido);
        }
    }
}
