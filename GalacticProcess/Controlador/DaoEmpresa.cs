using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticProcess.Controlador
{
    class DaoEmpresa
    {
        Conexion con;
        public DaoEmpresa()
        {

        }

        public int RegistrarEmpresa(string RutEmpresa, string NombreEmpresa, int TelefonoEmpresa, string EmailEmpresa, string DireccionEmpresa, string nombreImagen, int Comuna, int GiroComercial)
        {
            try
            {
                con = new Conexion();
                int respuesta = 0;
                object[] parametros = new object[8];
                parametros[0] = RutEmpresa.ToString();
                parametros[1] = NombreEmpresa.ToString();
                parametros[2] = TelefonoEmpresa;
                parametros[3] = EmailEmpresa.ToString();
                parametros[4] = DireccionEmpresa.ToString();
                parametros[5] = nombreImagen.ToString();
                parametros[6] = Comuna;
                parametros[6] = GiroComercial;
                
                return respuesta;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
