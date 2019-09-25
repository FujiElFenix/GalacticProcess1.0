using GalacticProcess.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalacticProcess.Modelo;

namespace GalacticProcess.Controlador
{
    class ComunaDao
    {
        

        
        public IEnumerable<Comuna_CL> ObtenerComuna()
        {
            try
            {
                Conexion con = new Conexion();
                string query = "SELECT * FROM COMUNA";
                List<Comuna_CL> tps = new List<Comuna_CL>();
                DataTable dt = new DataTable();
                dt = con.ExecuteQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    Comuna_CL tp = new Comuna_CL();
                    tp.ID_COMUNA = int.Parse(dr["ID_COMUNA"].ToString());
                    tp.NOMBRE_COMUNA = dr["NOMBRE_COMUNA"].ToString();
                    tps.Add(tp);
                }
                return tps;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

