
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticProcess.Modelo
{
    public class Conexion
    {
        OracleConnection connection = null;
        OracleCommand command = null;
        OracleDataReader reader = null;

        private string oradb = "Data Source=localhost:1521/xe;User Id=galacticfuji;Password=1234";

        public DataTable ExecuteQuery(string query)
        {
            connection = new OracleConnection(oradb);
            try
            {
                connection.Open();
                OracleCommand selectCommand = new OracleCommand(query, connection);
                selectCommand.CommandType = CommandType.Text;
                OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(selectCommand);
                DataTable dt = new DataTable();
                oracleDataAdapter.Fill(dt);
                selectCommand.Dispose();
                oracleDataAdapter.Dispose();
                if (dt.Rows.Count > 0)
                {
                    return dt;
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
            finally
            {
                connection.Close();
            }
        }
    }

}
