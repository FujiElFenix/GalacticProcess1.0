using GalacticProcess.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticProcess.Controlador
{
    class DaoComuna
    {
       Conexion con;

        public DaoComuna()
        {

        }

        public IEnumerable<Comuna_CL> ObtenerComuna()
        {
            try
            {
                con = new Conexion();
                List<Comuna_CL> Comunas = new List<Comuna_CL>();
                DataTable dt = new DataTable();
                string query = "SELECT * FROM COMUNA";

                dt = con.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Comuna_CL Comuna = new Comuna_CL();
                        Comuna.ID_COMUNA = int.Parse(dr["ID_COMUNA"].ToString());
                        Comuna.NOMBRE_COMUNA = dr["NOMBRE_COMUNA"].ToString();
                       


                        Comunas.Add(Comuna);
                    }
                    return Comunas;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

    }
}
