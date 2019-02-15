using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class GeneralBitacora
    {
        public int IdBitacora { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public bool Error { get; set; }

        public GeneralUsuarios IdUsuarioNavigation { get; set; }
    }
}
