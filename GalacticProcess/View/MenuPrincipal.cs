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
    public partial class MenuPrincipal : MetroFramework.Forms.MetroForm
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MTModuloUsuario_Click(object sender, EventArgs e)
        {
            ModuloUsuario MU = new ModuloUsuario();
            MU.Show();
        }
    }
}
