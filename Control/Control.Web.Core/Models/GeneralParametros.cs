using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class GeneralParametros
    {
        public int IdParametro { get; set; }
        public int ConsecutivoFacturas { get; set; }
        public bool EnviarFactura { get; set; }
        public string NombreEmpresa { get; set; }
        public string DetalleFacturas { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Identificacion { get; set; }
        public string RutaLogo { get; set; }
        public string RutaSistema { get; set; }
        public string HostCorreo { get; set; }
        public int? PortCorreo { get; set; }
        public int? TimeOutCorreo { get; set; }
        public string UserNameCorreo { get; set; }
        public string PasswordCorreo { get; set; }
        public string FromCorreo { get; set; }
        public string DisplayNameCorreo { get; set; }
        public string CorreoContactoRespaldos { get; set; }
    }
}
