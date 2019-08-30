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
    public partial class RegistroDeEmpresa : MetroFramework.Forms.MetroForm
    {
        public RegistroDeEmpresa()
        {
            InitializeComponent();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (TxtRut.Text == "" && TxtNombre.Text == "" && TxtDireccion.Text == "" && TxtCorreo.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\nRecuerde LLenar Todos Los Campos", "Error Al Registrar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
            
        }
    }
}
