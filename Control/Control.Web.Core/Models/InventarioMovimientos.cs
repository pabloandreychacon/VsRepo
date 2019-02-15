using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class InventarioMovimientos
    {
        public int IdMovimientoInventario { get; set; }
        public int IdProducto { get; set; }
        public int IdTipoMovimiento { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public InventarioProductos IdProductoNavigation { get; set; }
        public InventarioTiposMovimientos IdTipoMovimientoNavigation { get; set; }
    }
}
