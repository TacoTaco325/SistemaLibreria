using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class clsLibroConex
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CnnConexion"].ConnectionString);
        DataTable tbl = new DataTable();
        DataSet ds = null;
        SqlDataAdapter dap = null;

        public DataTable ListarLibroDatos(int id)
        {
            using (SqlCommand cmd = new SqlCommand("sp_listarLibroDatos", cn))
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

        public DataTable TotalVentasHoy(string Dia)
        {
            tbl = new DataTable();
            dap = new SqlDataAdapter();
            dap = new SqlDataAdapter("Select SUM(Costo),COUNT(idBoleta) from Boleta where Fecha='"+Dia+"'", cn);
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

        public DataTable TotalVentasMes(string Mes)
        {
            tbl = new DataTable();
            dap = new SqlDataAdapter();
            dap = new SqlDataAdapter("Select SUM(Costo),COUNT(idBoleta) from Boleta where MONTH(Fecha)='" + Mes + "'", cn);
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

        public DataTable LibroStock()
        {
            using (SqlCommand cmd = new SqlCommand("sp_alertastock", cn))
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



        public DataTable ListarLiCaAu()
        {
            using (SqlCommand cmd = new SqlCommand("sp_listarLiCaAu", cn))
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

        public DataTable ListarCaja()
        {
            using (SqlCommand cmd = new SqlCommand("sp_listarlibrocaja", cn))
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

        public DataTable BuscarLibroCaja(String Cadena)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Buscarlibrocaja", cn))
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

        public DataSet LlenarCombo()
        {
            try
            {
                ds = new DataSet();
                dap = new SqlDataAdapter("sp_cbocategoria", cn);
                dap.Fill(ds, "tcategoria");
                dap = new SqlDataAdapter("sp_cboautor", cn);
                dap.Fill(ds, "tautor");

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return ds;
        }

        public DataTable Buscar(String Cadena)
        {
            using (SqlCommand cmd = new SqlCommand("sp_buscarLibro", cn))
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

        public DataTable Eliminar(int Cadena)
        {
            using (SqlCommand cmd = new SqlCommand("sp_EliminarLibro", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int,10).Value = Cadena;
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

        public DataTable NuevoLibro(string nombre,int categoria,int isbm,int stock,decimal precio,int autor,bool estado)
        {
            using (SqlCommand cmd = new SqlCommand("sp_agregarlibro", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 255).Value = nombre;
                cmd.Parameters.Add("@cat", SqlDbType.Int, 10).Value = categoria;
                cmd.Parameters.Add("@ISBM", SqlDbType.Int, 10).Value = isbm;
                cmd.Parameters.Add("@stock", SqlDbType.Int, 10).Value = stock;
                cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
                cmd.Parameters.Add("@autor", SqlDbType.Int, 10).Value = autor;
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

        public DataTable modificarLibro(int id, string nombre, int categoria, int isbm, int stock, decimal precio, int autor, bool estado)
        {
            using (SqlCommand cmd = new SqlCommand("sp_modificarlibro", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 255).Value = nombre;
                cmd.Parameters.Add("@cat", SqlDbType.Int, 10).Value = categoria;
                cmd.Parameters.Add("@ISBM", SqlDbType.Int, 10).Value = isbm;
                cmd.Parameters.Add("@stock", SqlDbType.Int, 10).Value = stock;
                cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
                cmd.Parameters.Add("@autor", SqlDbType.Int,10).Value = autor;
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

    }
}
