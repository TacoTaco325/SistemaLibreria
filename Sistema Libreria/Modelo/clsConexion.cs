 using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using Entidad;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Modelo
{
    public class clsConexion
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CnnConexion"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataAdapter dap = null;
        DataTable dt = null;

        public bool validar(string usuario, string contraseña)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_validarusu", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu", usuario);
                cmd.Parameters.AddWithValue("@cont", contraseña);
                SqlDataReader drd = cmd.ExecuteReader();
                if (drd.HasRows)
                {
                    while (drd.Read())
                    {
                        clsEmpleado.idEmp = drd.GetInt32(0);
                        clsEmpleado.usuario = drd.GetString(1);
                        clsEmpleado.contraseña = drd.GetString(2);
                        clsEmpleado.nombre = drd.GetString(3);
                        clsEmpleado.apellido = drd.GetString(4);
                        clsEmpleado.direccion = drd.GetString(5);
                        clsEmpleado.DNI = drd.GetInt32(6);
                        clsEmpleado.salario = (float)drd.GetDouble(7);
                        clsEmpleado.idCargo = drd.GetInt32(8);
                        clsEmpleado.estado = drd.GetBoolean(9);
                        clsEmpleado.nomcargo = drd.GetString(10);

                    }
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool alertaStock()
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_alertastock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drd = cmd.ExecuteReader();
                if (drd.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EjecutaQuery(string opcion)
        {
            cmd = new SqlCommand();

            switch (opcion)
            {
                case "RO":
                    cmd = new SqlCommand("INSERT INTO OrdenCompra(idEmp,idPro,fecha,Hora) VALUES ('"+clsOrdenCompra.idEmp+"','"+clsOrdenCompra.idPro+"','"+clsOrdenCompra.fecha+"','"+clsOrdenCompra.Hora+"')", cn);
                    break;
                case "RDO":
                    cmd = new SqlCommand("INSERT INTO DetalleOrdenCompra(descripcion,idOC,cantidad) VALUES ('"+clsDetalleOrden.descripcion+"','"+clsDetalleOrden.idOC+"','"+clsDetalleOrden.Cantidad+"')", cn);
                    break;
                case "RV":
                    cmd = new SqlCommand("INSERT INTO Boleta ( Tipo,Fecha,Costo,Cliente,Pago,idEmp,Efectivo,Devolucion,Hora) VALUES ('"+clsBoleta.tipo+"','"+clsBoleta.fecha+"','"+clsBoleta.Costo+"','"+clsBoleta.cliente+"','"+clsBoleta.pago+"','"+clsBoleta.idEmp+"','"+clsBoleta.Efectivo+"','"+clsBoleta.devolucion+"','"+ clsBoleta.Hora+"')", cn);
                    break;
                case "RDV":
                    cmd = new SqlCommand("INSERT INTO DetalleBoleta (idLibro,Cantidad,Costo,idBoleta,PrecioUnitario) VALUES ('"+clsDetalleBoleta.idLibro+"','"+clsDetalleBoleta.Cantidad+"','"+clsDetalleBoleta.Costo+"','"+clsDetalleBoleta.idBoleta+"','"+clsDetalleBoleta.precioUni+"')", cn);
                    break;
                case "ASV":
                    cmd = new SqlCommand("UPDATE Libro SET stock = stock - "+clsDetalleBoleta.Cantidad+" WHERE idLibro="+clsDetalleBoleta.idLibro+"", cn);
                    break;
                case "RC":
                    cmd = new SqlCommand("INSERT INTO Compra (Fecha,Costo,idEmp,idPro,Hora) VALUES('"+clsCompra.Fecha+"','"+clsCompra.Costo+"','"+clsCompra.idEmp+"','"+clsCompra.idPro+"','"+clsCompra.Hora+"')", cn);
                    break;
                case "RDC":
                    cmd = new SqlCommand("INSERT INTO DetalleCompra (idCompra,idLibro,cantidad,costo,preciounitario) VALUES ('" + clsDetalleCompra.idCompra+"','"+clsDetalleCompra.idLibro+"','"+clsDetalleCompra.Cantidad+"','"+clsDetalleCompra.Costo+"','"+clsDetalleCompra.PrecioUni+"')", cn);
                    break;
                case "ASC":
                    cmd = new SqlCommand("UPDATE Libro SET stock=stock + "+clsDetalleCompra.Cantidad+" WHERE idLibro= "+clsDetalleCompra.idLibro+"", cn);
                    break;
            }
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable EjecutaQueryID(string opcion)
        {
            dt = new DataTable();
            dap = new SqlDataAdapter();

            switch (opcion)
            {
                case "IDO":
                    dap = new SqlDataAdapter("SELECT MAX(idOC) FROM OrdenCompra", cn);
                    break;
                case "IDB":
                    dap = new SqlDataAdapter("SELECT MAX(idBoleta) FROM Boleta", cn);
                    break;
                case "IDC":
                    dap = new SqlDataAdapter("SELECT MAX(idCompra) FROM Compra", cn);
                    break;
            }
            try
            {
                cn.Open();
                dap.Fill(dt);
                cn.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return dt;
        }

        public DataTable NuevaSugerencia(string sug,string fecha)
        {
            dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand("sp_agregarSugerencia", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 255).Value = sug;
                cmd.Parameters.Add("@fecha", SqlDbType.VarChar, 255).Value = fecha;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return dt;
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
