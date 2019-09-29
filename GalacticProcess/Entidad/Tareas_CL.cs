using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticProcess.Entidad
{
    public class Tareas_CL
    {
        public int ID_TAREA { get; set; }
        public string NOMBRE_TAREA { get; set; }
        public string DESCRIPCION_TAREA { get; set; }
        public int DIAS_DURACION { get; set; }
        
        public Tareas_CL()
        {

        }
    }
}
