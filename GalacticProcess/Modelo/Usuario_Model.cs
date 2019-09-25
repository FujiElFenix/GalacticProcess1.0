
using GalacticProcess.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticProcess.Modelo
{
    public class Usuario_Model
    {
        public Conexion conexion { get; set; }

        public Usuario_Model()
        {
            conexion = new Conexion();
        }

        public int AutenticarUsuario(Usuario_CL usuario)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "LOGIN_ESCRITORIO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_USER", usuario.Username);
                cmd.Parameters.Add("PRM_PASS", usuario.Password);
                cmd.Parameters.Add("TIPO_USUARIO", OracleType.Number);
                cmd.Parameters["TIPO_USUARIO"].Direction = ParameterDirection.ReturnValue;
                cmd.Connection = conexion.Conectar();
                cmd.ExecuteNonQuery();
                int tipo_usuario = int.Parse(Convert.ToString(cmd.Parameters["TIPO_USUARIO"].Value));
                return tipo_usuario;
            }
            catch(Exception e)
            {
                return 0;
            }
        }
    }

   
}
