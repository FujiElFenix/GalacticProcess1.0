using GalacticProcess.Entidad;
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

        public void CargarComboBox()
        {
            //Cargar Comunas
            Empresa_Model model = new Empresa_Model();
            List<Comuna_CL> comunas = new List<Comuna_CL>();
            var dataSourceComunas = new List<Comuna_CL>();
            comunas = model.ListarComunas();
            foreach (Comuna_CL item in comunas)
            {
                dataSourceComunas.Add(new Comuna_CL() { id_comuna = item.id_comuna, nombre_comuna= item.nombre_comuna});
            }
            cboComuna.DataSource = dataSourceComunas;
            cboComuna.DisplayMember = "nombre_comuna";
            cboComuna.ValueMember = "id_comuna";
            //Cargar Giros
            List<GiroComercial_CL> giros = new List<GiroComercial_CL>();
            var dataSourceGiros = new List<GiroComercial_CL>();
            giros = model.ListarGiros();
            foreach (GiroComercial_CL item in giros)
            {
                dataSourceGiros.Add(new GiroComercial_CL() { id_giro = item.id_giro, desc_giro = item.desc_giro });
            }
            cboGiro.DataSource = dataSourceGiros;
            cboGiro.DisplayMember = "desc_giro";
            cboGiro.ValueMember = "id_giro";


        }
    }
}
