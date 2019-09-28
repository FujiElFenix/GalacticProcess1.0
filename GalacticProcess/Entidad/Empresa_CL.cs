using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticProcess.Entidad
{
    public class Empresa_CL 
    {
        public int id_empresa { get; set; }
        public string rut_empresa { get; set; }
        public string nombre_empresa { get; set; }
        public int telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string imagen_empresa { get; set; }

        public int id_comuna { get; set; }
        public int id_giro { get; set; }
        public Empresa_CL()
        {

        }
    }
}
