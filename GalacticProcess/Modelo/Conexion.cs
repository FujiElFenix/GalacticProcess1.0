
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticProcess.Modelo
{
    public class Conexion
    {
        OracleConnection connection = null;

        private string oradb = "Data Source=localhost:1521/xe;User Id=PRUEBASPORTAFOLIO2;Password=1234";

        public OracleConnection Conectar()
        {
            try
            {
                connection = new OracleConnection(oradb);
                connection.Open();
                return connection;
            }catch(Exception e)
            {
                return null;
            }
        }
        public void CerrarConexion()
        {
            try
            {
                connection = new OracleConnection(oradb);
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
