using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalacticProcess.Entidad;
using System.Data.OracleClient;
using System.Data;

namespace GalacticProcess.Modelo
{
    class Tarea_Model
    {
        public Conexion conexion { get; set; }
        Tareas_CL tarea;
        List<Tareas_CL> tareas;
        public Tarea_Model()
        {
            conexion = new Conexion();
        }
        internal bool RegistrarTareas(Tareas_CL tareas)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Conectar();
                cmd.CommandText = "PKG_TAREAS.REGISTRAR_TAREA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("PRM_NOM", OracleType.VarChar).Value = tareas.NOMBRE_TAREA;
                cmd.Parameters.Add("PRM_DESC", OracleType.VarChar).Value = tareas.DESCRIPCION_TAREA;
                cmd.Parameters.Add("PRM_DURACION", OracleType.Number).Value = tareas.DIAS_DURACION;
                

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Tareas_CL> ListarTareas()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Conectar();
                cmd.CommandText = "PKG_TAREAS.LISTAR_TAREAS";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("TAREAS", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                tareas = new List<Tareas_CL>();
                foreach (DataRow dr in tabla.Rows)
                {
                    tarea = new Tareas_CL()
                    {
                        ID_TAREA = int.Parse(dr[0].ToString()),
                        NOMBRE_TAREA = dr[1].ToString(),
                        DESCRIPCION_TAREA = dr[2].ToString(),
                        DIAS_DURACION = int.Parse(dr[3].ToString()),
                        
                    };
                    tareas.Add(tarea);
                }
                return tareas;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        internal Tareas_CL BuscarTarea(int id_tarea)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Conectar();
                cmd.CommandText = "PKG_TAREAS.BUSCAR_TAREA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("TAREAS", OracleType.Cursor).Direction = ParameterDirection.Output;//TAREAS O TAREA
                cmd.Parameters.Add("PRM_ID", OracleType.Number).Value = id_tarea;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                foreach (DataRow dr in tabla.Rows)
                {
                    tarea = new Tareas_CL()
                    {
                        ID_TAREA = int.Parse(dr[0].ToString()),
                        NOMBRE_TAREA = dr[1].ToString(),
                        DESCRIPCION_TAREA = dr[2].ToString(),
                        DIAS_DURACION = int.Parse(dr[3].ToString()),
                       
                    };
                }
                return tarea;
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

        internal bool ModificarTareas(Tareas_CL tarea)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Conectar();
                cmd.CommandText = "PKG_TAREAS.MODIFICAR_TAREA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("PRM_NOM", OracleType.VarChar).Value = tarea.NOMBRE_TAREA;
                cmd.Parameters.Add("PRM_DESC", OracleType.VarChar).Value = tarea.DESCRIPCION_TAREA;
                cmd.Parameters.Add("PRM_DURACION", OracleType.Number).Value = tarea.DIAS_DURACION;
                cmd.Parameters.Add("PRM_ID", OracleType.VarChar).Value = tarea.ID_TAREA;

                cmd.ExecuteNonQuery();

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        internal bool EliminarTareas(int id_tarea)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Conectar();
                cmd.CommandText = "PKG_TAREAS.ELIMINAR_TAREA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("PRM_ID", OracleType.Number).Value = id_tarea;
                cmd.ExecuteNonQuery();

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
    }
}
