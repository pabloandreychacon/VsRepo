using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class VentasClientes
    {
        public VentasClientes()
        {
            VentasDocumentos = new HashSet<VentasDocumentos>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public ICollection<VentasDocumentos> VentasDocumentos { get; set; }
    }
}
