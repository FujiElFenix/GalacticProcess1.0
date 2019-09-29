using GalacticProcess.Entidad;
using GalacticProcess.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalacticProcess.View
{
    public partial class ModuloTareas : MetroFramework.Forms.MetroForm
    {
        public ModuloTareas()
        {
            InitializeComponent();
            CargarTareas();
        }
        List<Tareas_CL> tareas; //Lista de empresas que usaremos para listarlas, valga la redundancia
        Tareas_CL tarea; //Objeto que posteriormente instanciaremos para manejar la información de una empresa
        Tarea_Model model;
        int[] id_tareas = new int[1000]; //arreglo de enteros en donde se almacenarán los ids de las empresas al momento de listarlas
        int id_tarea;
        int index;
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {

            //Inicialización
            Tarea_Model model = new Tarea_Model(); // Inicializamos el objeto del modelo
            Tareas_CL tareas = new Tareas_CL(); // Inicializamos el objeto de la empresa
            //Recogida de datos, lo guardaremos todo en el objeto empresa
            tareas.NOMBRE_TAREA = TxtNombreTarea.Text;
            tareas.DESCRIPCION_TAREA = TxtDescripcion.Text;
            tareas.DIAS_DURACION = int.Parse(TxtDuracion.Text);
            //Declaramos la variable en donde almacenamos la respuesta del modelo
            bool respuesta = model.RegistrarTareas(tareas); //Llamamos al método del modelo

            if (respuesta) //Si se agrega
            {
                MessageBox.Show("Empresa Registrada");
            }
            else //Si no
            {
                MessageBox.Show("Empresa No Registrada"); //Ya tu sabes, cambialos por los de metro
            }
        }

        public void CargarTareas()
        {
            try
            {
                //Inicialización
                model = new Tarea_Model();
                tareas = model.ListarTareas(); //Llamamos al método listar
                int contador = 0; //Este objeto servirá para ir llenando el arreglo de los id y para ir aumentando las filas del datagrid
                //Añadimos las columnas de datagrid
                MGTareas.Columns.Add("Nombre", "Nombre");
                MGTareas.Columns.Add("Descripcion", "Descripcion");
                MGTareas.Columns.Add("Dias", "Dias");
               
                //Si existen datos
                if (tareas != null)
                {
                    foreach (Tareas_CL tarea in tareas) //Recorremos la lista de empresas
                    {
                        MGTareas.Rows.Add(); //Añadimos una nueva fila
                        DataGridViewRow row = MGTareas.Rows[contador]; //Definimos una nueva fila datagrid y le asignamos la posición
                        //Llenado de la fila creada
                        row.Cells[0].Value = tarea.NOMBRE_TAREA;
                        row.Cells[1].Value = tarea.DESCRIPCION_TAREA;
                        row.Cells[2].Value = tarea.DIAS_DURACION.ToString();
                        

                        id_tareas[contador] = tarea.ID_TAREA; //Agregamos un nuevo id al arreglo de ids
                        contador++; //Sumamos 1 al contador para cada vuelta de ciclo
                    }
                    MGTareas.CellClick += MGTareas_CellContentClick; //Al clickear en una celda, esto se usará para buscar
                }//Más adelante veremos que hacemos si no hay datos
            }
            catch (Exception e)
            {
                //Más adelante vemos como manejamos las excepciones
            }
        }

        private void MGTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                MessageBox.Show("Columna no válida");
                return;
            }
            if (MGTareas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) //Si el valor de la columna clickada es distinto de null
            {
                HabilitarCamposModificar();
                id_tarea = id_tareas[e.RowIndex]; //Asignamos el id de la empresa según la posición dentro del arreglo de ids
                index = e.RowIndex; //Indicamos la posición del objeto
                Tareas_CL tarea = model.BuscarTarea(id_tarea); //Llamamos al método para buscar una empresa 
                //Cargamos los input de la vista con la información de la empresa
                TxtNTarea.Text = tarea.NOMBRE_TAREA;
                TxtDTarea.Text = tarea.DESCRIPCION_TAREA;
                TxtDuTareas.Text = tarea.DIAS_DURACION.ToString();
                

            }            
        }
        private void HabilitarCamposModificar()
        {
            TxtNTarea.Enabled = true;
            TxtDTarea.Enabled = true;
            TxtDuTareas.Enabled = true;
            
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            //Sigue la misma lógica del agregar
            tarea = new Tareas_CL();
            tarea.ID_TAREA = id_tarea;
            tarea.NOMBRE_TAREA = TxtNTarea.Text;
            tarea.DESCRIPCION_TAREA = TxtDTarea.Text;
            tarea.DIAS_DURACION = int.Parse(TxtDuTareas.Text);
 
            bool respuesta = model.ModificarTareas(tarea);
            if (respuesta)
            {
                MessageBox.Show("Tarea Modificada");
                DeshabilitarCamposModificar();
                CargarTareas();
            }
            else
            {
                MessageBox.Show("Error al modificar la Tarea");
            }
        }
        private void DeshabilitarCamposModificar()
        {
            TxtNTarea.Enabled = false;
            TxtDTarea.Enabled = false;
            TxtDuTareas.Enabled = false;


            TxtNTarea.Text = "";
            TxtDTarea.Text = "";
            TxtDuTareas.Text = "";
            
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            bool respuesta = model.EliminarTareas(id_tarea); //Declaramos un booleano en donde almacenaremos la respuesta
            if (respuesta)
            {
                MessageBox.Show("Tarea Eliminada");
                DeshabilitarCamposModificar();
                MGTareas.Rows.RemoveAt(index); //Removemos el elemento del combobox al que pertenece el elemento eliminado
            }
            else
            {
                MessageBox.Show("Error al eliminar la Tarea");
            }
        }
    }
 }

