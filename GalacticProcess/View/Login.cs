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
using System.Data.OracleClient;
using GalacticProcess.Controlador;

namespace GalacticProcess
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        OracleConnection ora = new OracleConnection("DATA SOURCE = ex; PASSWORD = 1234; USER ID = galacticfuji;");
        private void Bttn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                string user = TxtUsername.Text;
                string pass = TxtPassword.Text;
                Usuario_Controller controller = new Usuario_Controller();
                int validacion_usuario = controller.ValidarUsuario(user, pass);
                if (validacion_usuario == 1)
                {
                    MessageBox.Show("Admin");
                }
                else if (validacion_usuario == 2)
                {
                    MessageBox.Show("Diseñador");
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña inválida");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("No Conectado"+ ex.Message);
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
