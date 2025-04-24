using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sol_Minimarket.Entidades;
using System.Data;


namespace Sol_Minimarket.Datos
{
    public class D_Categorias
    {
        public DataTable Listado_ca(String cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Listado_ca", SQLCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SQLCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open) SQLCon.Close();
            }
        }
        public string Guardar_ca(int nOpcion, E_Categorias oCa)
        {
            string Rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando =  new SqlCommand("USP_Guardar_ca", Sqlcon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nOpcion", SqlDbType.Int).Value = nOpcion;
                Comando.Parameters.Add("nCodigo_ca", SqlDbType.Int).Value = oCa.Codigo_ca;
                Comando.Parameters.Add("@nDescripcion_ca", SqlDbType.VarChar).Value = oCa.Descripcion_ca;
                Sqlcon.Open();
                Rpta = Comando.ExecuteNonQuery()==1 ? "OK" : "No se pueden registrar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open) Sqlcon.Close();
            }
            return Rpta;
        }
    }
}
