using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class InventarioCategorias
    {
        public InventarioCategorias()
        {
            InventarioProductos = new HashSet<InventarioProductos>();
        }

        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }

        public ICollection<InventarioProductos> InventarioProductos { get; set; }
    }
}
