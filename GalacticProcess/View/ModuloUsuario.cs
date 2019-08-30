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
    public partial class ModuloUsuario : MetroFramework.Forms.MetroForm
    {
        public ModuloUsuario()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
        }

       

        private void metroTile1_Click(object sender, EventArgs e)
        {
            
        }

        private void MTTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (MTTema.SelectedIndex)
            {
                case 0:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                    break;
                case 1:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
                
            }
        }

        private void MCBColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroStyleManager1.Style = (MetroFramework.MetroColorStyle)Convert.ToInt32(MCBColor.SelectedIndex);
        }

        private void ModuloUsuario_Load(object sender, EventArgs e)
        {
            MCBColor.SelectedIndex = 0;
            MTTema.SelectedIndex = 0;
        }

        private void metroListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
