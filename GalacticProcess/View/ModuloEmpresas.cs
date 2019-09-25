using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalacticProcess.View
{
    public partial class ModuloEmpresas : MetroFramework.Forms.MetroForm
    {
        public ModuloEmpresas()
        {
            InitializeComponent();
        }

        
        private void BtnEmpresa1_Click(object sender, EventArgs e)
        {
            



           
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbxImgProducto.Image = new Bitmap(ofd.FileName);
                string nombreImagen = ofd.FileName.ToString();
                nombreImagen = nombreImagen.Substring(nombreImagen.LastIndexOf("\\"));
                nombreImagen = nombreImagen.Remove(0, 1);
                pbxImgProducto.Tag = nombreImagen;
            }
        }
    }
}
