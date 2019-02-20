using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public class Printing
    {
        /// <summary>
        /// properties
        /// </summary>
        public string Text { get; set; }
        public int FontSize { get; set; }
        public string FontName { get; set; }
        public int LeftMargin { get; set; }
        public int RightMargin { get; set; }
        public int TopMargin { get; set; }
        public int BottomMargin { get; set; }
        /// <summary>
        /// fields
        /// </summary>
        private PrintDocument pdoc = new PrintDocument();
        private TextBox txtDocument = new TextBox();
        static int intCurrentChar;
        //private string text = "UAT-UAMCAV";
        private int fontsize = 10;
        private string fontname = "Courier New";
        int leftmargin = 0;
        //int rightmargin = 0;
        int topmargin = 0;
        //int bottommargin = 0;
        /// <summary>
        /// Punto de entrada de la clase
        /// </summary>
        /// <param name=prmText">Texto que será impreso</param>"
        public Printing(string textToPrint)
        {
            InitializeComponent();
            txtDocument.Text = textToPrint;
            leftmargin = pdoc.DefaultPageSettings.Margins.Left;
            topmargin = pdoc.DefaultPageSettings.Margins.Top;
        }

        protected void InitializeComponent()
        {
            pdoc.PrintPage += new PrintPageEventHandler(Doc_PrintPage);
        }

        /// <summary>
        /// Mandar directamente a la impresora
        /// </summary>
        public void Print()
        {
            PrintDialog dialog = new PrintDialog();
            dialog.Document = pdoc;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pdoc.Print();
            }
        }

        public void PrintPreview()
        {
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            try
            {
                ppd.Document = pdoc;
                ppd.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error al intentar cargar " +
                    "la vista preeliminar el documento", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font(fontname, fontsize);
            int intPrintAreaHeight;
            int intPrintAreaWidth;
            intPrintAreaHeight = pdoc.DefaultPageSettings.PaperSize.Height -
                pdoc.DefaultPageSettings.Margins.Top -
                pdoc.DefaultPageSettings.Margins.Bottom;
            intPrintAreaWidth = pdoc.DefaultPageSettings.PaperSize.Width -
                pdoc.DefaultPageSettings.Margins.Left -
                pdoc.DefaultPageSettings.Margins.Right;
            if (pdoc.DefaultPageSettings.Landscape)
            {
                int intTemp = intPrintAreaHeight;
                intPrintAreaHeight = intPrintAreaWidth;
                intPrintAreaWidth = intTemp;
            }
            int intLineCount = (int)(intPrintAreaHeight / font.Height);
            RectangleF rectPrintingArea = new RectangleF(leftmargin, topmargin,
                intPrintAreaWidth, intPrintAreaHeight);
            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);
            int intLinesFilled;
            int intCharsFitted;
            e.Graphics.MeasureString(txtDocument.Text.Substring(intCurrentChar), font,
                new SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt,
                out intCharsFitted, out intLinesFilled);
            e.Graphics.DrawString(txtDocument.Text.Substring(intCurrentChar), font,
                Brushes.Black, rectPrintingArea, fmt);
            intCurrentChar += intCharsFitted;
            if (intCurrentChar < (txtDocument.Text.Length - 1))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                intCurrentChar = 0;
            }
        }
    }
}
