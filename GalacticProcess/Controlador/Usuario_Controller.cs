using GalacticProcess.Entidad;
using GalacticProcess.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticProcess.Controlador
{
    public class Usuario_Controller
    {
        public int ValidarUsuario(string user, string pass)
        {
            try
            {
                Usuario_CL usuario = new Usuario_CL();
                usuario.Username = user;
                usuario.Password = pass;
                Usuario_Model model = new Usuario_Model();
                return model.AutenticarUsuario(usuario);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
