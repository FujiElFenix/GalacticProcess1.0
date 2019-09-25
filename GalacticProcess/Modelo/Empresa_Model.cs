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
    class Empresa_Model
    {
        public Conexion conexion { get; set; }
        Comuna_CL comuna;
        List<Comuna_CL> comunas;
        GiroComercial_CL giro;
        List<GiroComercial_CL> giros;
        public Empresa_Model()
        {
            conexion = new Conexion();
        }

        public List<Comuna_CL> ListarComunas()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Conectar();
                cmd.CommandText = "PKG_COMUNA.LISTAR_COMUNAS";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("COMUNAS", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                comunas = new List<Comuna_CL>();
                foreach (DataRow dr in tabla.Rows)
                {
                    comuna = new Comuna_CL()
                    {
                        id_comuna = int.Parse(dr[0].ToString()),
                        nombre_comuna = dr[1].ToString()
                    };
                    comunas.Add(comuna);
                }
                return comunas;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<GiroComercial_CL> ListarGiros()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Conectar();
                cmd.CommandText = "PKG_GIRO_COMERCIAL.LISTAR_GIROS";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("GIROS", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                giros = new List<GiroComercial_CL>();
                foreach (DataRow dr in tabla.Rows)
                {
                    giro = new GiroComercial_CL()
                    {
                        id_giro = int.Parse(dr[0].ToString()),
                        desc_giro = dr[1].ToString()
                    };
                    giros.Add(giro);
                }
                return giros;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
    }
}
