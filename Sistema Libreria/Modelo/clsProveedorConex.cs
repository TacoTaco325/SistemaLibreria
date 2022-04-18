using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class clsProveedorConex
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CnnConexion"].ConnectionString);
        DataTable tbl = new DataTable();
        DataSet ds = null;
        SqlDataAdapter dap = null;

        public DataTable Listar()
        {
            using (SqlCommand cmd = new SqlCommand("sp_ListarProv", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(tbl);
                    if (tbl.Rows.Count > 0)
                    {
                        return tbl;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public DataTable Buscar(String Cadena)
        {
            using (SqlCommand cmd = new SqlCommand("sp_buscarProv", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 40).Value = Cadena;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(tbl);
                    if (tbl.Rows.Count > 0)
                    {
                        return tbl;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public DataTable NuevoProv(string nombre, string correo, string contacto, string ciudad, string direccion, int telf, decimal porcentaje, bool estado)
        {
            using (SqlCommand cmd = new SqlCommand("sp_agregarprov", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 255).Value = nombre;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar,255).Value = correo;
                cmd.Parameters.Add("@contacto", SqlDbType.VarChar, 255).Value = contacto;
                cmd.Parameters.Add("@ciudad", SqlDbType.VarChar, 255).Value = ciudad;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar,255).Value = direccion;
                cmd.Parameters.Add("@telf", SqlDbType.Int, 10).Value = telf;
                cmd.Parameters.Add("@porcentaje", SqlDbType.Decimal).Value = porcentaje;
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(tbl);
                    if (tbl.Rows.Count > 0)
                    {
                        return tbl;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public DataTable ModificarProv(int id, string nombre, string correo, string contacto, string ciudad, string direccion, int telf, decimal porcentaje, bool estado)
        {
            using (SqlCommand cmd = new SqlCommand("sp_modificarprov", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int, 10).Value = id;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 255).Value = nombre;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar, 255).Value = correo;
                cmd.Parameters.Add("@contacto", SqlDbType.VarChar, 255).Value = contacto;
                cmd.Parameters.Add("@ciudad", SqlDbType.VarChar, 255).Value = ciudad;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 255).Value = direccion;
                cmd.Parameters.Add("@telf", SqlDbType.Int, 10).Value = telf;
                cmd.Parameters.Add("@porcentaje", SqlDbType.Decimal).Value = porcentaje;
                cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = estado;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(tbl);
                    if (tbl.Rows.Count > 0)
                    {
                        return tbl;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public DataTable EliminarProv(int id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_EliminarProv", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int,10).Value = id;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(tbl);
                    if (tbl.Rows.Count > 0)
                    {
                        return tbl;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public DataTable BuscarCorreo(int id)
        {
            tbl = new DataTable();
            dap = new SqlDataAdapter();
            dap = new SqlDataAdapter("select Correo_E from Proveedores where idPro="+id+" and estado= 1", cn);
            try
            {
                cn.Open();
                dap.Fill(tbl);
                cn.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return tbl;
        }
    }
}
