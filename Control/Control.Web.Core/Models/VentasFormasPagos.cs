using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class VentasFormasPagos
    {
        public VentasFormasPagos()
        {
            VentasPagos = new HashSet<VentasPagos>();
        }

        public int IdFormaPago { get; set; }
        public string Descripcion { get; set; }

        public ICollection<VentasPagos> VentasPagos { get; set; }
    }
}
