using GalacticProcess.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BunifuAnimatorNS;

namespace GalacticProcess
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Bttn_Login_Click(object sender, EventArgs e)
        {
            if (TxtUsername.Text == "Admin" && TxtPassword.Text == "Admin")
            {
                MenuAdministrador ma = new MenuAdministrador();
                ma.Show();
            }
            else if (TxtUsername.Text == "Diseñador" && TxtPassword.Text == "Diseñador")
            {
                MenuDiseñador md = new MenuDiseñador();
                md.Show();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\nRecuerde Ingresar Credenciales Correctas y LLenar Todos Los Campos", "Error Al Ingresar Al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }


        private void PictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox1.SendToBack();
            Animate_BackLogo();
        }
        private BunifuAnimatorNS.AnimationType AnimationType = (AnimationType)10;
        public void Animate_BackLogo()
        {

            if (PictureBox1.Visible == true)
                bunifuTransition1.HideSync(PictureBox1);

            PictureBox1.Visible = false;
            //pictureBox4.BringToFront();

            bunifuTransition1.AnimationType = AnimationType;
            bunifuTransition1.ShowSync(PictureBox1);

            if (AnimationType == (AnimationType)13)
                AnimationType = (AnimationType)1;
            else
                AnimationType += 1;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
