using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class VentasDetalleVentas
    {
        public int IdDetalle { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Descuento { get; set; }
        public decimal? TotalLinea { get; set; }

        public InventarioProductos IdProductoNavigation { get; set; }
        public VentasDocumentos IdVentaNavigation { get; set; }
    }
}
