using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Modelo;

namespace Controlador
{
    public class clsLibroMgr
    {
        clsLibroConex objlibcon = new clsLibroConex();
        clsLibro objLibro = null;
        DataTable tbl = null;
        DataSet ds = null;


        public DataTable ListarLibroDatos(int id)
        {
            try
            {
                return objlibcon.ListarLibroDatos(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public DataTable LibroStock()
        {
            try
            {
                return objlibcon.LibroStock();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public DataTable TotalVentasHoy(string dia)
        {
            return objlibcon.TotalVentasHoy(dia);
        }

        public DataTable TotalVentasMes(string mes)
        {
            return objlibcon.TotalVentasMes(mes);
        }


        public DataTable ListarLiCaAu()
        {

            tbl = new DataTable();
            try
            {
                tbl = objlibcon.ListarLiCaAu();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return tbl;
        }

        public DataTable ListarCaja()
        {

            tbl = new DataTable();
            try
            {
                tbl = objlibcon.ListarCaja();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return tbl;
        }

        public DataSet LlenarCombo()
        {
            try
            {
                ds = objlibcon.LlenarCombo();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return ds;
        }

        public DataTable BuscarLibro(string nom)
        {
            tbl = new DataTable();

            try
            {
                tbl = objlibcon.Buscar(nom);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tbl;
        }

        public DataTable BuscarLibroCaja(string nom)
        {
            tbl = new DataTable();

            try
            {
                tbl = objlibcon.BuscarLibroCaja(nom);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tbl;
        }

        public void Nuevo(string nombre,int categoria, int isbm, int stock, decimal precio, int autor, bool estado)
        {
            try
            {
                objlibcon.NuevoLibro(nombre, categoria, isbm, stock, precio, autor, estado);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void modificar(int id, string nombre, int categoria, int isbm, int stock, decimal precio, int autor, bool estado)
        {
            try
            {
                objlibcon.modificarLibro(id,nombre,categoria, isbm, stock,  precio,  autor,  estado);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(int ID)
        {
            try
            {
                objlibcon.Eliminar(ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


            
    }
}
