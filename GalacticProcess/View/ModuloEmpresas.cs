using GalacticProcess.Entidad;
using GalacticProcess.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalacticProcess.View
{
    public partial class ModuloEmpresas : MetroFramework.Forms.MetroForm
    {
        List<Empresa_CL> empresas;
        Empresa_CL empresa;
        Empresa_Model model;
        int[] ids_empresas = new int[1000];
        int id_empresa;
        int index;
        public ModuloEmpresas()
        {
            InitializeComponent();
            CargarComboBox();
            CargarEmpresas();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Empresa_Model model = new Empresa_Model();

            Empresa_CL empresa = new Empresa_CL();
            empresa.rut_empresa = TxtRut.Text;
            empresa.nombre_empresa = TxtNombre.Text;
            empresa.telefono = int.Parse(TxtTelefono.Text);
            empresa.email = TxtCorreo.Text;
            empresa.direccion = TxtDireccion.Text;
            empresa.id_comuna = int.Parse(cboComuna.SelectedValue.ToString());
            empresa.id_giro = int.Parse(cboGiro.SelectedValue.ToString());
            empresa.imagen_empresa = pbxImgEmpresa.Tag.ToString();
            bool respuesta = model.RegistrarEmpresa(empresa);

            if (respuesta)
            {
                MessageBox.Show("Empresa Registrada");
                Bitmap b = new Bitmap(pbxEmpresa2.Image);
                string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Imagenes\\" + empresa.imagen_empresa;
                if (!File.Exists(path))
                {
                    b.Save(path, ImageFormat.Jpeg);
                }
                CargarEmpresas();
            }
            else
            {
                MessageBox.Show("Empresa No Registrada");
            }
        }



        private void metroButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbxImgEmpresa.Image = new Bitmap(ofd.FileName);
                string nombreImagen = ofd.FileName.ToString();
                nombreImagen = nombreImagen.Substring(nombreImagen.LastIndexOf("\\"));
                nombreImagen = nombreImagen.Remove(0, 1);
                pbxImgEmpresa.Tag = nombreImagen;
            }
        }

        public void CargarEmpresas()
        {
            try
            {
                DataTable dt = new DataTable();
                model = new Empresa_Model();
                empresas = model.ListarEmpresas();
                int contador = 0;

                MGEmpresas.Columns.Add("Rut", "Rut");
                MGEmpresas.Columns.Add("Nombre", "Nombre");
                MGEmpresas.Columns.Add("Telefono", "Telefono");
                MGEmpresas.Columns.Add("Email", "Email");

                if (empresas != null)
                {
                    foreach (Empresa_CL empresa in empresas)
                    {
                        MGEmpresas.Rows.Add();
                        DataGridViewRow row = MGEmpresas.Rows[contador];

                        row.Cells[0].Value = empresa.rut_empresa;
                        row.Cells[1].Value = empresa.nombre_empresa;
                        row.Cells[2].Value = empresa.telefono.ToString();
                        row.Cells[3].Value = empresa.email;

                        ids_empresas[contador] = empresa.id_empresa;
                        contador++;

                    }

                    MGEmpresas.CellClick += MGEmpresas_CellClick;

                }
            }
            catch (Exception e)
            {

            }
        }

        private void MGEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MGEmpresas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id_empresa = ids_empresas[e.RowIndex];
                index = e.RowIndex;
                Empresa_CL empresa = model.BuscarEmpresa(id_empresa);
                txtRut2.Text = empresa.rut_empresa;
                txtNombre2.Text = empresa.nombre_empresa;
                txtDireccion2.Text = empresa.direccion;
                txtTelefono2.Text = empresa.telefono.ToString();
                txtCorreo2.Text = empresa.email;

                //cboComuna2.SelectedIndex = cboComuna2.FindStringExact(empresa.c.ToString());
                if (empresa.imagen_empresa != "")
                {
                    pbxEmpresa2.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Imagenes\\" + empresa.imagen_empresa);
                }

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
                dataSourceComunas.Add(new Comuna_CL() { id_comuna = item.id_comuna, nombre_comuna = item.nombre_comuna });
            }
            cboComuna.DataSource = dataSourceComunas;
            cboComuna.DisplayMember = "nombre_comuna";
            cboComuna.ValueMember = "id_comuna";

            cboComuna2.DataSource = dataSourceComunas;
            cboComuna2.DisplayMember = "nombre_comuna";
            cboComuna2.ValueMember = "id_comuna";
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

            cboGiro2.DataSource = dataSourceGiros;
            cboGiro2.DisplayMember = "desc_giro";
            cboGiro2.ValueMember = "id_giro";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            empresa = new Empresa_CL();
            empresa.id_empresa = id_empresa;
            empresa.rut_empresa = txtRut2.Text;
            empresa.nombre_empresa = txtNombre2.Text;
            empresa.telefono = int.Parse(txtTelefono2.Text);
            empresa.email = txtCorreo2.Text;
            empresa.direccion = txtDireccion2.Text;
            empresa.id_comuna = int.Parse(cboComuna2.SelectedValue.ToString());
            empresa.id_giro = int.Parse(cboGiro2.SelectedValue.ToString());
            empresa.imagen_empresa = pbxEmpresa2.Tag.ToString();
            bool respuesta = model.ModificarEmpresa(empresa);
            if (respuesta)
            {
                MessageBox.Show("Empresa Modificada");
                Bitmap b = new Bitmap(pbxEmpresa2.Image);
                string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Imagenes\\" + empresa.imagen_empresa;
                if (!File.Exists(path))
                {
                    b.Save(path, ImageFormat.Jpeg);
                }
                CargarEmpresas();
            }
            else
            {
                MessageBox.Show("Error al modificar la empresa");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool respuesta = model.EliminarEmpresa(id_empresa);
            if (respuesta)
            {
                MessageBox.Show("Empresa Eliminada");
                MGEmpresas.Rows.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Error al eliminar la empresa");
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbxEmpresa2.Image = new Bitmap(ofd.FileName);
                string nombreImagen = ofd.FileName.ToString();
                nombreImagen = nombreImagen.Substring(nombreImagen.LastIndexOf("\\"));
                nombreImagen = nombreImagen.Remove(0, 1);
                pbxEmpresa2.Tag = nombreImagen;
            }
        }
    }
}
