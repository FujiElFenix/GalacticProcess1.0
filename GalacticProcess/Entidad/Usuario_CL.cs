using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticProcess.Entidad
{
    public class Usuario_CL : TipoUsuario_CL
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int TipoUsuario { get; set; }

        public Usuario_CL()
        {

        }
    }
}
