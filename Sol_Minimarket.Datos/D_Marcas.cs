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
    public class D_Marcas
    {
        public DataTable Listado_ma(String cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLCon = new SqlConnection();

            try
            {
                SQLCon = Conexion.GetConnection();
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
        public string Guardar_ma(int nOpcion, E_Marcas oMa)
        {
            string Rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.GetConnection();
                SqlCommand Comando =  new SqlCommand("USP_Guardar_ca", Sqlcon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nOpcion", SqlDbType.Int).Value = nOpcion;
                Comando.Parameters.Add("@nCodigo_ma", SqlDbType.Int).Value = oMa.Codigo_ma;
                Comando.Parameters.Add("@cDescripcion_ma", SqlDbType.VarChar).Value = oMa.Descripcion_ma;
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
        public string Eliminar_ma(int Codigo_ma)
        {
            string Rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = Conexion.GetConnection();
                SqlCommand Comando = new SqlCommand("USP_Eliminar_ca", Sqlcon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nCodigo_ma", SqlDbType.Int).Value = Codigo_ma;
                Sqlcon.Open();  
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pueden eliminar los datos";
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
