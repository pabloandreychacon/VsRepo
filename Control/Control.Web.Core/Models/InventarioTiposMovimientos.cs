using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class InventarioTiposMovimientos
    {
        public InventarioTiposMovimientos()
        {
            InventarioMovimientos = new HashSet<InventarioMovimientos>();
        }

        public int IdTipoMovimiento { get; set; }
        public bool Positivo { get; set; }
        public string Nombre { get; set; }

        public ICollection<InventarioMovimientos> InventarioMovimientos { get; set; }
    }
}
