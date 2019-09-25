using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticProcess.Controlador
{
    class Conexion
    {
        OracleConnection connection = null;
        OracleCommand command = null;
        OracleDataReader reader = null;

        private string oradb = "Data Source=localhost:1521/xe;User Id=galacticfuji;Password=123457";

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


        public int ExecSP(string SP, params object[] parametros)
        {
            try
            {
                OracleConnection cn = new OracleConnection(oradb);
                OracleCommand cmd = new OracleCommand(SP, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                OracleCommandBuilder.DeriveParameters(cmd);
                int cuenta = 0;

                foreach (OracleParameter pr in cmd.Parameters)
                {
                    if (pr.ParameterName != "RETURN_VALUE")
                    {
                        pr.Value = parametros[cuenta];
                        cuenta++;
                    }
                }
                int res = cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }

    }
}

