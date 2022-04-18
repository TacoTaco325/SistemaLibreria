using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Modelo
{
    public class clsCategoriaConex
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CnnConexion"].ConnectionString);
        DataTable tbl = new DataTable();
        DataSet ds = null;
        SqlDataAdapter dap = null;

        public DataTable Listar()
        {
            using (SqlCommand cmd = new SqlCommand("sp_ListarCate", cn))
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
        public DataTable Buscar(String nombre)
        {
            using (SqlCommand cmd = new SqlCommand("sp_buscarCat", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 40).Value = nombre;
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

        public DataTable NuevoCat(string nombre, bool estado)
        {
            using (SqlCommand cmd = new SqlCommand("sp_agregarCate", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 40).Value = nombre;
                cmd.Parameters.Add("@est", SqlDbType.Bit).Value = estado;
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

        public DataTable ModificarCat(int id, string nombre, bool estado)
        {
            using (SqlCommand cmd = new SqlCommand("sp_modificarCate", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int, 10).Value = id;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 40).Value = nombre;
                cmd.Parameters.Add("@est", SqlDbType.Bit).Value = estado;
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

        public DataTable EliminarCat(int id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_EliminarCate", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int, 10).Value = id;
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
    }
}
