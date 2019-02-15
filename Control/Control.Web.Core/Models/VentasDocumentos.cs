using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class VentasDocumentos
    {
        public VentasDocumentos()
        {
            VentasDetalleVentas = new HashSet<VentasDetalleVentas>();
            VentasPagos = new HashSet<VentasPagos>();
        }

        public int IdVenta { get; set; }
        public int Consecutivo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalVenta { get; set; }
        public int IdCliente { get; set; }
        public decimal TotalImpuestos { get; set; }
        public decimal TotalDescuentos { get; set; }
        public bool Activo { get; set; }
        public bool Enviado { get; set; }

        public VentasClientes IdClienteNavigation { get; set; }
        public ICollection<VentasDetalleVentas> VentasDetalleVentas { get; set; }
        public ICollection<VentasPagos> VentasPagos { get; set; }
    }
}
