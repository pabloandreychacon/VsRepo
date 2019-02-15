using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class ProveeduriaProveedores
    {
        public ProveeduriaProveedores()
        {
            InventarioProductos = new HashSet<InventarioProductos>();
        }

        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Identificacion { get; set; }

        public ICollection<InventarioProductos> InventarioProductos { get; set; }
    }
}
