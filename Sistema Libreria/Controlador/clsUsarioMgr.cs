using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Entidad;
using Modelo;

namespace Controlador
{
    public class clsUsuarioMgr
    {
        clsConexion objconexion = new clsConexion();
        clsUsuario objUsuario = null;
        DataTable tbl = null;

        public clsUsuarioMgr()
        {
            
        }

        public bool Validar(string usuario, string contraseña)
        {
            return objconexion.validar(usuario, contraseña);
        }

        public bool AlertaStock()
        {
            return objconexion.alertaStock();
        }

        public void EjecutaQuery(string opcion)
        {
            objconexion.EjecutaQuery(opcion);
        }

        public DataTable EjecutaQueryID(string opcion)
        {
            return objconexion.EjecutaQueryID(opcion);
        }

        public DataTable NuevaSugerencia(string descripcion, string fecha)
        {
            try
            {
                return objconexion.NuevaSugerencia(descripcion, fecha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
