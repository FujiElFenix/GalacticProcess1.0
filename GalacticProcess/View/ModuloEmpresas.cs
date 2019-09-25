using GalacticProcess.Controlador;
using GalacticProcess.Modelo;
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
        private DaoEmpresa daoEmpresa;

        public ModuloEmpresas()
        {
            InitializeComponent();
            CargarComboBox();
        }

        
        private void BtnEmpresa1_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            daoEmpresa = new DaoEmpresa();
            
            string rutRutEmpresa = TxtRut.Text;
            string NombreEmpresa = TxtNombre.Text;
            int TelefonoEmpresa = int.Parse(TxtTelefono.Text);
            string EmailEmpresa = TxtCorreo.Text;
            string DireccionEmpresa = TxtDireccion.Text;
            string nombreImagen = pbxImgProducto.Tag.ToString();
            int Comuna = int.Parse(cboComuna.SelectedValue.ToString());
            int GiroComercial = int.Parse(CboGiroComercial.SelectedValue.ToString());



            int respuesta = daoEmpresa.RegistrarEmpresa(rutRutEmpresa, NombreEmpresa, TelefonoEmpresa, EmailEmpresa, DireccionEmpresa, nombreImagen, Comuna, GiroComercial);
            if (respuesta == 1)
            {
                MessageBox.Show("Empresa Registrado");
                Bitmap b = new Bitmap(pbxImgProducto.Image);
                string path = @"C:\Users\Pipe Feanco\Desktop\Ultimo semestre\Portafolio\EscritorioC#\GalacticProcess\GalacticProcess\View\Imagenes\" + nombreImagen;
                b.Save(path);
               
            }
            else
            {
                MessageBox.Show("No se ha podido registrar la Empresa");
            }
        }

        private void CargarComboBox()
        {
            //Cargo los Comuna
            DaoComuna daoCom = new DaoComuna();
            List<Comuna_CL> Comunas = new List<Comuna_CL>();
            Comunas = (List<Comuna_CL>)daoCom.ObtenerComuna();
            var dataSourceProveedor = new List<Comuna_CL>();
            foreach (Comuna_CL item in Comunas)
            {
                dataSourceProveedor.Add(new Comuna_CL() { NOMBRE_COMUNA = item.NOMBRE_COMUNA, ID_COMUNA = item.ID_COMUNA });
            }
            cboComuna.DataSource = dataSourceProveedor;
            cboComuna.DisplayMember = "NOMBRE_COMUNA";
            cboComuna.ValueMember = "ID_COMUNA";
            //Cargo Giro Comercial
            
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
