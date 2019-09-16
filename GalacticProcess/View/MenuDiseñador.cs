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
    public partial class MenuDiseñador : MetroFramework.Forms.MetroForm
    {
        public MenuDiseñador()
        {
            InitializeComponent();
        }

        private void BtnModuloTareas_Click(object sender, EventArgs e)
        {
            ModuloTareas MT = new ModuloTareas();
            MT.Show();
        }

        private void BtnFlujoTrabajo_Click(object sender, EventArgs e)
        {
            FlujoTareas FT = new FlujoTareas();
            FT.Show();
        }
    }
}
