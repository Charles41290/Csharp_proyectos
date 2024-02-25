using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProductoDTO
    {
        // Atributos
        private long id;
        private string descripcion;
        private decimal costo;
        private decimal precioVenta;
        private int stock;
        private long idUsuario;

        // Getters and Setters
        public long Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public decimal Costo
        {
            get
            {
                return this.costo;
            }
            set
            {
                this.costo = value;
            }

        }

        public decimal PrecioVenta
        {
            get
            {
                return this.precioVenta;
            }
            set
            {
                this.precioVenta = value;
            }

        }

        public int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                this.stock = value;
            }

        }

        public long IdUsuario
        {
            get
            {
                return this.idUsuario;
            }
            set
            {
                this.idUsuario = value;
            }

        }
    }
}
