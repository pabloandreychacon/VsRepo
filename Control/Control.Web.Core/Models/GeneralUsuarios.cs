using System;
using System.Collections.Generic;

namespace Control.Web.Core.Models
{
    public partial class GeneralUsuarios
    {
        public GeneralUsuarios()
        {
            GeneralBitacora = new HashSet<GeneralBitacora>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public bool Administrador { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }

        public ICollection<GeneralBitacora> GeneralBitacora { get; set; }
    }
}
