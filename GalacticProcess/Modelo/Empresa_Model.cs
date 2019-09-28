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
        Empresa_CL empresa;
        List<Empresa_CL> empresas;
        public Empresa_Model()
        {
            conexion = new Conexion();
        }

        public bool RegistrarEmpresa(Empresa_CL empresa)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Conectar();
                cmd.CommandText = "PKG_EMPRESAS.REGISTRAR_EMPRESA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("PRM_RUT", OracleType.VarChar).Value = empresa.rut_empresa;
                cmd.Parameters.Add("PRM_NOM", OracleType.VarChar).Value = empresa.nombre_empresa;
                cmd.Parameters.Add("PRM_IMG", OracleType.VarChar).Value = empresa.imagen_empresa;
                cmd.Parameters.Add("PRM_TEL", OracleType.Number).Value = empresa.telefono;
                cmd.Parameters.Add("PRM_EMAIL", OracleType.VarChar).Value = empresa.email;
                cmd.Parameters.Add("PRM_DIRECCION", OracleType.VarChar).Value = empresa.direccion;
                cmd.Parameters.Add("PRM_COM", OracleType.Number).Value = empresa.id_comuna;
                cmd.Parameters.Add("PRM_GIRO", OracleType.Number).Value = empresa.id_giro;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Empresa_CL> ListarEmpresas()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Conectar();
                cmd.CommandText = "PKG_EMPRESAS.LISTAR_EMPRESAS";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("EMPRESAS", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                empresas = new List<Empresa_CL>();
                foreach (DataRow dr in tabla.Rows)
                {
                    empresa = new Empresa_CL()
                    {
                        id_empresa = int.Parse(dr[0].ToString()),
                        rut_empresa = dr[1].ToString(),
                        nombre_empresa = dr[2].ToString(),
                        telefono = int.Parse(dr[3].ToString()),
                        email = dr[4].ToString(),
                        direccion = dr[5].ToString(),
                        imagen_empresa = dr[6].ToString(),
                        id_comuna = int.Parse(dr[7].ToString()),
                        id_giro = int.Parse(dr[8].ToString())
                    };
                    empresas.Add(empresa);
                }
                return empresas;
            }
            catch (Exception e)
            {
                return null;
            }
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
            finally
            {
                conexion.CerrarConexion();
            }
        }

        internal Empresa_CL BuscarEmpresa(int id_empresa)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Conectar();
                cmd.CommandText = "PKG_EMPRESAS.BUSCAR_EMPRESA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("EMPRESAS", OracleType.Cursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PRM_ID", OracleType.Number).Value = id_empresa;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                foreach (DataRow dr in tabla.Rows)
                {
                    empresa = new Empresa_CL()
                    {
                        id_empresa = int.Parse(dr[0].ToString()),
                        rut_empresa = dr[1].ToString(),
                        nombre_empresa = dr[2].ToString(),
                        telefono = int.Parse(dr[3].ToString()),
                        email = dr[4].ToString(),
                        direccion = dr[5].ToString(),
                        imagen_empresa = dr[6].ToString(),
                        id_comuna = int.Parse(dr[7].ToString()),
                        id_giro = int.Parse(dr[8].ToString())
                    };
                }
                return empresa;
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

        internal bool EliminarEmpresa(int id_empresa)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Conectar();
                cmd.CommandText = "PKG_EMPRESAS.ELIMINAR_EMPRESA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("PRM_ID", OracleType.Number).Value = id_empresa;
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

        internal bool ModificarEmpresa(Empresa_CL empresa)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conexion.Conectar();
                cmd.CommandText = "PKG_EMPRESAS.MODIFICAR_EMPRESA";
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("PRM_RUT", OracleType.VarChar).Value = empresa.rut_empresa;
                cmd.Parameters.Add("PRM_NOM", OracleType.VarChar).Value = empresa.nombre_empresa;
                cmd.Parameters.Add("PRM_TEL", OracleType.Number).Value = empresa.telefono;
                cmd.Parameters.Add("PRM_IMG", OracleType.VarChar).Value = empresa.imagen_empresa;
                cmd.Parameters.Add("PRM_EMAIL", OracleType.VarChar).Value = empresa.email;
                cmd.Parameters.Add("PRM_DIRECCION", OracleType.VarChar).Value = empresa.direccion;
                cmd.Parameters.Add("PRM_COM", OracleType.Number).Value = empresa.id_comuna;
                cmd.Parameters.Add("PRM_GIRO", OracleType.Number).Value = empresa.id_giro;
                cmd.Parameters.Add("PRM_ID", OracleType.Number).Value = empresa.id_empresa;
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
