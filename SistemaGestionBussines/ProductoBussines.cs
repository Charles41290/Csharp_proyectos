using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using SistemaGestionData;
using DTOs;

namespace SistemaGestionBussines
{
    public  class ProductoBussines
    {
        public  List<Producto> GetAllProductos()
        {
            return ProductoData.ListarProductos();
        }

        public  Producto GetProductById(int id)
        {
            return ProductoData.ObtenerProductoPorId(id);
        }

        public  bool CreateProduct(ProductoDTO producto)
        {
            // genero un Producto a partir de ProductoDTO y lo utilizo para el metodo de AgregarProducto
            Producto p = new Producto();
            p.Descripcion = producto.Descripcion;
            p.PrecioVenta = producto.PrecioVenta;
            p.Stock = producto.Stock;
            p.IdUsuario = producto.IdUsuario;
            return ProductoData.AgregarProducto(p);
        }

        public bool DeleteProductById(int id) 
        {
            return ProductoData.BorrarProductoPorId(id);
        }

        public  bool UpdateProductById(int id, Producto producto)
        {
            return ProductoData.ActualizaProductoPorId(id, producto);
        }
    }
}
