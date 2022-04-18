using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Modelo;
using System.Threading.Tasks;

namespace Controlador
{
    public class clsProveedorMgr
    {
        clsProveedorConex objProCon = new clsProveedorConex();
        DataTable tbl = null;
        DataSet ds = null;

        public DataTable ListarProv()
        {

            tbl = new DataTable();
            try
            {
                tbl = objProCon.Listar();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return tbl;
        }

        public DataTable Buscar(string nom)
        {
            tbl = new DataTable();
            try
            {
                tbl = objProCon.Buscar(nom);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return tbl;
        }

        public void NuevoProv(string Nombre, string Correo, string contacto, string ciudad, string direccion, int telf, decimal porce, bool estado)
        {
            try
            {
                objProCon.NuevoProv(Nombre, Correo, contacto, ciudad, direccion, telf, porce, estado);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void ModificarProv(int id, string Nombre, string Correo, string contacto, string ciudad, string direccion, int telf, decimal porce, bool estado)
        {
            try
            {
                objProCon.ModificarProv(id,Nombre, Correo, contacto, ciudad, direccion, telf, porce, estado);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void EliminarProv(int id)
        {
            try
            {
                objProCon.EliminarProv(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable BuscarCorreo(int id)
        {
            return objProCon.BuscarCorreo(id);
        }
    }
}
