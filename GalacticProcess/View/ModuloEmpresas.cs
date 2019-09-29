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

/*
    Hola amigo pipe, voy a comentarte un poco el código para 
    que entiendas un poco lo que vas a programar
     */

namespace GalacticProcess.View
{
    public partial class ModuloEmpresas : MetroFramework.Forms.MetroForm
    {
        List<Empresa_CL> empresas; //Lista de empresas que usaremos para listarlas, valga la redundancia
        Empresa_CL empresa; //Objeto que posteriormente instanciaremos para manejar la información de una empresa
        Empresa_Model model; //objeto con el cual accederemos a los métodos del modelo
        int[] ids_empresas = new int[1000]; //arreglo de enteros en donde se almacenarán los ids de las empresas al momento de listarlas
        int id_empresa; //Este objeto manejará el id de una única empresa
        int index; //Este numero me servirá para determinar la posición de una empresa dentro de una lista
        public ModuloEmpresas()
        {
            InitializeComponent();
            CargarComboBox(); //Lo que te la ganó
            CargarEmpresas(); //Carga el listado de empresas dentro de la vista
            DeshabilitarCamposModificar(); //Método para deshabilitar los campos del modificar por defecto, no quiero que me ingresen cualquier cosa
        }
        //Para realizar un nuevo registro
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            //Inicialización
            Empresa_Model model = new Empresa_Model(); // Inicializamos el objeto del modelo
            Empresa_CL empresa = new Empresa_CL(); // Inicializamos el objeto de la empresa
            //Recogida de datos, lo guardaremos todo en el objeto empresa
            empresa.rut_empresa = TxtRut.Text;
            empresa.nombre_empresa = TxtNombre.Text;
            empresa.telefono = int.Parse(TxtTelefono.Text);
            empresa.email = TxtCorreo.Text;
            empresa.direccion = TxtDireccion.Text;
            empresa.id_comuna = int.Parse(cboComuna.SelectedValue.ToString());
            empresa.id_giro = int.Parse(cboGiro.SelectedValue.ToString());
            empresa.imagen_empresa = pbxImgEmpresa.Tag.ToString(); //Ojo que recogemos el nombre
            //Declaramos la variable en donde almacenamos la respuesta del modelo
            bool respuesta = model.RegistrarEmpresa(empresa); //Llamamos al método del modelo

            if (respuesta) //Si se agrega
            {
                MessageBox.Show("Empresa Registrada");
                Bitmap b = new Bitmap(pbxImgEmpresa.Image); //Declaramos el objeto con el que manejamos la imágen
                string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Imagenes\\" + empresa.imagen_empresa; //Declaramos la ruta
                if (!File.Exists(path)) //Validamos si la imagen ya existe
                {
                    b.Save(path, ImageFormat.Jpeg); //Si no existe, la guarda
                }
                CargarEmpresas(); //Recargamos la lista para que se muestre la última empresa registrada
            }
            else //Si no
            {
                MessageBox.Show("Empresa No Registrada"); //Ya tu sabes, cambialos por los de metro
            }
        }


        //Para cargar una imágen desde un directorio
        private void metroButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();//Delaramos un nuevo diálogo para ingresar archivos
            ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;)|*.jpg"; //Definimos el formato de los archivos a detectar
            if (ofd.ShowDialog() == DialogResult.OK) //Si se selecciona una imágen
            {
                pbxImgEmpresa.Image = new Bitmap(ofd.FileName); //Cargamos la imágen en el picture box
                string nombreImagen = ofd.FileName.ToString(); //Declaramos y rescatamos el nombre de la imágen que almacenaremos en la base de datos
                nombreImagen = nombreImagen.Substring(nombreImagen.LastIndexOf("\\")); //Tomamos solamente el nombre de la imágen y no la ruta completa
                nombreImagen = nombreImagen.Remove(0, 1);
                pbxImgEmpresa.Tag = nombreImagen; //Al picturebox le asignamos el valor del nombre de la imágen
            }
        }
        //Para listar las empresas existentes
        public void CargarEmpresas()
        {
            try
            {
                //Inicialización
                model = new Empresa_Model(); 
                empresas = model.ListarEmpresas(); //Llamamos al método listar
                int contador = 0; //Este objeto servirá para ir llenando el arreglo de los id y para ir aumentando las filas del datagrid
                //Añadimos las columnas de datagrid
                MGEmpresas.Columns.Add("Rut", "Rut");
                MGEmpresas.Columns.Add("Nombre", "Nombre");
                MGEmpresas.Columns.Add("Telefono", "Telefono");
                MGEmpresas.Columns.Add("Email", "Email");
                //Si existen datos
                if (empresas != null)
                {
                    foreach (Empresa_CL empresa in empresas) //Recorremos la lista de empresas
                    {
                        MGEmpresas.Rows.Add(); //Añadimos una nueva fila
                        DataGridViewRow row = MGEmpresas.Rows[contador]; //Definimos una nueva fila datagrid y le asignamos la posición
                        //Llenado de la fila creada
                        row.Cells[0].Value = empresa.rut_empresa;
                        row.Cells[1].Value = empresa.nombre_empresa;
                        row.Cells[2].Value = empresa.telefono.ToString();
                        row.Cells[3].Value = empresa.email;

                        ids_empresas[contador] = empresa.id_empresa; //Agregamos un nuevo id al arreglo de ids
                        contador++; //Sumamos 1 al contador para cada vuelta de ciclo
                    }
                    MGEmpresas.CellClick += MGEmpresas_CellClick; //Al clickear en una celda, esto se usará para buscar
                }//Más adelante veremos que hacemos si no hay datos
            }
            catch (Exception e)
            {
                //Más adelante vemos como manejamos las excepciones
            }
        }
        //Al cliclear una celda del datagrid
        private void MGEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                MessageBox.Show("Columna no válida");
                return;
            }
            if (MGEmpresas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) //Si el valor de la columna clickada es distinto de null
            {
                HabilitarCamposModificar();
                id_empresa = ids_empresas[e.RowIndex]; //Asignamos el id de la empresa según la posición dentro del arreglo de ids
                index = e.RowIndex; //Indicamos la posición del objeto
                Empresa_CL empresa = model.BuscarEmpresa(id_empresa); //Llamamos al método para buscar una empresa 
                //Cargamos los input de la vista con la información de la empresa
                txtRut2.Text = empresa.rut_empresa;
                txtNombre2.Text = empresa.nombre_empresa;
                txtDireccion2.Text = empresa.direccion;
                txtTelefono2.Text = empresa.telefono.ToString();
                txtCorreo2.Text = empresa.email;

                //cboComuna2.SelectedIndex = cboComuna2.FindStringExact(empresa.c.ToString());
                if (empresa.imagen_empresa != "")
                {
                    pbxEmpresa2.Image = new Bitmap( Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Imagenes\\" + empresa.imagen_empresa));//Si la empresa tiene imágen, la cargamos
                    pbxEmpresa2.Tag = empresa.imagen_empresa;
                }

            }


        }
        //Lo que te la ganó
        public void CargarComboBox()
        {
            //Cargar Comunas
            Empresa_Model model = new Empresa_Model(); //Inicializamo el modelo
            List<Comuna_CL> comunas = new List<Comuna_CL>(); //Inicializamos una nueva lista de comunas
            var dataSourceComunas = new List<Comuna_CL>(); //creamos un datasource con un listado de comunas
            comunas = model.ListarComunas(); //Llamamos al método para listar comunas
            foreach (Comuna_CL item in comunas)//Recorremos las comunas
            {
                dataSourceComunas.Add(new Comuna_CL() { id_comuna = item.id_comuna, nombre_comuna = item.nombre_comuna }); //Añadimos un nuevo objeto comuna al datasource
            }
            //Combo del agregar
            cboComuna.DataSource = dataSourceComunas; //Le asignamos el datasource como fuente de datos al combobox
            cboComuna.DisplayMember = "nombre_comuna"; //Incidamos el miembro que se mostrará
            cboComuna.ValueMember = "id_comuna"; //Indicamos el miembro que rescataremos
            //Combo del modificar
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
        //Para modificar una empresa
        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Sigue la misma lógica del agregar
            empresa = new Empresa_CL();
            empresa.id_empresa = id_empresa;
            empresa.rut_empresa = txtRut2.Text;
            empresa.nombre_empresa = txtNombre2.Text;
            empresa.telefono = int.Parse(txtTelefono2.Text);
            empresa.email = txtCorreo2.Text;
            empresa.direccion = txtDireccion2.Text;
            empresa.id_comuna = int.Parse(cboComuna2.SelectedValue.ToString());
            empresa.id_giro = int.Parse(cboGiro2.SelectedValue.ToString());
            if (pbxEmpresa2.Tag.ToString() != null)
            {
                empresa.imagen_empresa = pbxEmpresa2.Tag.ToString();
            }
            
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
                DeshabilitarCamposModificar();
                CargarEmpresas();
            }
            else
            {
                MessageBox.Show("Error al modificar la empresa");
            }
        }
        //Para eliminar una empresa
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool respuesta = model.EliminarEmpresa(id_empresa); //Declaramos un booleano en donde almacenaremos la respuesta
            if (respuesta)
            {
                MessageBox.Show("Empresa Eliminada");
                DeshabilitarCamposModificar();
                MGEmpresas.Rows.RemoveAt(index); //Removemos el elemento del combobox al que pertenece el elemento eliminado
            }
            else
            {
                MessageBox.Show("Error al eliminar la empresa");
            }
        }
        //Para cargar una imágen
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
        private void DeshabilitarCamposModificar()
        {
            txtRut2.Enabled = false;
            txtNombre2.Enabled = false;
            txtDireccion2.Enabled = false;
            txtTelefono2.Enabled = false;
            txtCorreo2.Enabled = false;
            cboComuna2.Enabled = false;
            cboGiro2.Enabled = false;
            metroButton1.Enabled = false;
            pbxEmpresa2.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            txtRut2.Text = "";
            txtNombre2.Text = "";
            txtDireccion2.Text = "";
            txtTelefono2.Text = "";
            txtCorreo2.Text = "";
            cboGiro2.SelectedIndex = 0;
            cboComuna2.SelectedIndex = 0;
        }
        private void HabilitarCamposModificar()
        {
            txtRut2.Enabled = true;
            txtNombre2.Enabled = true;
            txtDireccion2.Enabled = true;
           txtTelefono2.Enabled = true;
            txtCorreo2.Enabled = true;
            cboComuna2.Enabled = true;
            cboGiro2.Enabled = true;
            metroButton1.Enabled = true;
            pbxEmpresa2.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}
