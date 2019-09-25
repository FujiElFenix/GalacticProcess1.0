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
            daoProd = new DaoProducto();
            string nombreImagen = pbxImgProducto.Tag.ToString();
            string nombreProducto = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            int valor = int.Parse(txtValor.Text);
            int t_preparacion = int.Parse(txtTiempo.Text);
            int tipo_producto = int.Parse(cboTipoProducto.SelectedValue.ToString());
            int proveedor = int.Parse(cboProveedor.SelectedValue.ToString());



            int respuesta = daoProd.RegistrarProduto(nombreImagen, nombreProducto, descripcion, valor, t_preparacion, tipo_producto, proveedor);
            if (respuesta == 1)
            {
                MessageBox.Show("Producto Registrado");
                Bitmap b = new Bitmap(pbxImgProducto.Image);
                string path = @"C:\Users\Jose\Desktop\AplicacionEscritorio\AplicacionEscritorio\Imagenes\" + nombreImagen;
                string path2 = @"C:\wamp64\www\SantiagoEatsWeb1.0\public\imagenes\" + nombreImagen;
                b.Save(path);
                b.Save(path2);
            }
            else
            {
                MessageBox.Show("No se ha podido registrar el producto");
            }
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
