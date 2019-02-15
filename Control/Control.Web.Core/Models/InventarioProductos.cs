using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class InventarioProductos
    {
        public InventarioProductos()
        {
            InventarioMovimientos = new HashSet<InventarioMovimientos>();
            VentasDetalleVentas = new HashSet<VentasDetalleVentas>();
        }

        public int IdProducto { get; set; }
        public string Identificador { get; set; }
        public string Descripcion { get; set; }
        public int IdProveedor { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioVenta { get; set; }
        public int IdCategoria { get; set; }
        public decimal Impuestos { get; set; }
        public bool VerificaDisponible { get; set; }
        public decimal Descuento { get; set; }
        public decimal Utilidad { get; set; }

        public InventarioCategorias IdCategoriaNavigation { get; set; }
        public ProveeduriaProveedores IdProveedorNavigation { get; set; }
        public ICollection<InventarioMovimientos> InventarioMovimientos { get; set; }
        public ICollection<VentasDetalleVentas> VentasDetalleVentas { get; set; }
    }
}
