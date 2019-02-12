using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using BaseHelpers.Helpers;
using BaseForms.Forms;

namespace SqlExecute
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // leer cadena de conexion del config y pasarla a form
            var conn = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            if (Tools.FormManager.FindAndOpenForm("Scripts")) return;
            var formToShow = new Scripts();
            formToShow.txtConexion.Text = conn;
            //formToShow.Show();
            //Application.Run(new Form1());
            Application.Run(formToShow);
        }
    }
}
