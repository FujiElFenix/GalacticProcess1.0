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
            RegistroDeEmpresa RE = new RegistroDeEmpresa();
            RE.Show();
        }

        private void BtnListarEmpresas_Click(object sender, EventArgs e)
        {
            MostrarEmpresacs ME = new MostrarEmpresacs();
            ME.Show();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
