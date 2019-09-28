using GalacticProcess.Modelo;
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

        public int RegistrarEmpresa(string RutEmpresa, string NombreEmpresa, string descripcion, int valor, int t_preparacion, int tipo_producto, int proveedor)
        {
            try
            {
                con = new Conexion();
                int respuesta = 0;
                object[] parametros = new object[7];
                //parametros[0] = nombreImagen.ToString();
                //parametros[1] = nombreProducto.ToString();
                parametros[2] = descripcion.ToString();
                parametros[3] = valor;
                parametros[4] = t_preparacion;
                parametros[5] = tipo_producto;
                parametros[6] = proveedor;
                if (proveedor > 0)
                {
                   // respuesta = con.ExecSP("PKG_PRODUCTO.INSERT_PRODUCTO_EXTERNO", parametros);
                }
                else
                {
                    //respuesta = con.ExecSP("PKG_PRODUCTO.INSERT_PRODUCTO_INTERNO", parametros);
                }
                return respuesta;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        internal int RegistrarEmpresa(string rutRutEmpresa, string nombreEmpresa, int telefonoEmpresa, string emailEmpresa, string direccionEmpresa, string nombreImagen, int comuna, int giroComercial)
        {
            throw new NotImplementedException();
        }
    }
}
