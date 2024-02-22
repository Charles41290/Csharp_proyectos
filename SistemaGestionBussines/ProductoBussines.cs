﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using SistemaGestionData;

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

        public  bool CreateProduct(Producto producto)
        {
            return ProductoData.AgregarProducto(producto);
        }

        public  bool DeleteProductById(int id) 
        {
            return ProductoData.BorrarUsuarioPorId(id);
        }

        public  bool UpdateProductById(int id, Producto producto)
        {
            return ProductoData.ActualizaProductoPorId(id, producto);
        }
    }
}
