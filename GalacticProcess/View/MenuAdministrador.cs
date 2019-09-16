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
    public partial class MenuAdministrador : MetroFramework.Forms.MetroForm
    {
        public MenuAdministrador()
        {
            InitializeComponent();
        }

        private void BtnRegistrarEmpresa_Click(object sender, EventArgs e)
        {
           ;
        }

        private void BtnListarEmpresas_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click_2(object sender, EventArgs e)
        {
            ModuloEmpresas ME = new ModuloEmpresas();
            ME.Show();
        }

        private void MTModuloUnidades_Click(object sender, EventArgs e)
        {
            ModuloUnidades MU = new ModuloUnidades();
            MU.Show();

        }

        private void MTModuloUsuario_Click(object sender, EventArgs e)
        {
            ModuloUsuario mus = new ModuloUsuario();
            mus.Show();

        }

        private void MTModuloRoles_Click(object sender, EventArgs e)
        {
            ModuloRoles MR = new ModuloRoles();
            MR.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            ModuloTareas mt = new ModuloTareas();
            mt.Show();
        }
    }
}
