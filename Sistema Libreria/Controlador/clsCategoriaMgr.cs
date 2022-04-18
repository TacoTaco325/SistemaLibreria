using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Modelo;
using System.Threading.Tasks;

namespace Controlador
{
    public class clsCategoriaMgr
    {
        clsCategoriaConex objCatCon = new clsCategoriaConex();
        DataTable tbl = null;
        DataSet ds = null;

        public DataTable Listar()
        {
            tbl = new DataTable();
            try
            {
                tbl = objCatCon.Listar();
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
                tbl = objCatCon.Buscar(nom);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return tbl;
        }

        public void NuevoCat(string nom, bool est)
        {
            try
            {
                objCatCon.NuevoCat(nom,est);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void ModificarCat(int id, string nom, bool est)
        {
            try
            {
                objCatCon.ModificarCat(id, nom, est);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                objCatCon.EliminarCat(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
