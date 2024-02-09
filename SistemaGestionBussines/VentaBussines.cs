using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussines
{
    public class VentaBussines
    {
        public static List<Venta> GetAllSales()
        {
            return VentaData.ListarVentas();
        }

        public static Venta GetSaleById(int id)
        {
            return VentaData.ObtenerVentaPorId(id);
        }

        public static bool CreateSale(Venta venta)
        {
            return VentaData.AgregarVenta(venta);
        }

        public static bool DeleteSaleById(int id)
        {
            return VentaData.BorrarVentaPorId(id);
        }

        public static bool UpdateSaleById(int id, Venta venta)
        {
            return VentaData.ActualizarVentaPorId(id, venta);
        }
    }
}
