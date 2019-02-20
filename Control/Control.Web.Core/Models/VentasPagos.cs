using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class VentasPagos
    {
        public int IdPago { get; set; }
        public int IdVenta { get; set; }
        public int IdFormaPago { get; set; }
        public string NumeroChequeTarjeta { get; set; }
        public decimal MontoRecibido { get; set; }
        public decimal MontoAplicado { get; set; }

        public VentasFormasPagos IdFormaPagoNavigation { get; set; }
        public VentasDocumentos IdVentaNavigation { get; set; }
    }
}
