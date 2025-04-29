using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Data;

namespace Sol_Minimarket.Datos
{
    public class Conexion
    {
        private  string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;
        private static Conexion Con = null;

        public Conexion()
        {
            this.Base = "BD_Minimarket";
            this.Servidor = "DESKTOP-KIDS6OC\\SOLUSYSTEMS";
            this.Usuario = "Sistemas";
            this.Clave = "Solusystems2024*.";
            this.Seguridad = false;
        }

      
        public static SqlConnection GetConnection()
        {
            try
            {
           //     string strConnect = "Data Source=" + Class1.ServerSQL + ";Initial Catalog=" + Class1.BDSQL + ";User ID=" + Class1.UsuarioSQL + ";Password=" + Class1.ContrasenaSQL + "";
                string strConnect = "Data Source=" + Class1.ServerSQL + ";Initial Catalog=" + Class1.BDSQL + ";User ID=" + Class1.UsuarioSQL + ";Password=" + Class1.ContrasenaSQL + "";
                return new SqlConnection(strConnect);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
        public static DataTable ExtraeDatos(string Cmd, string NombreTabla = "DATOS")
        {
            DataTable dt = new DataTable();
            SqlConnection Cn = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(Cmd, Cn);

            try
            {
                Cn.Open();
                da.SelectCommand.Connection = Cn;
                da.Fill(dt);
                dt.TableName = NombreTabla;
                int ds = dt.Rows.Count;
            }
            catch (Exception ex)
            {
                try
                {
                    da = new SqlDataAdapter(("SET DATEFORMAT DMY; EXEC " + Cmd), Cn);
                    da.SelectCommand.Connection = Cn;
                    da.Fill(dt);
                    dt.TableName = NombreTabla;
                }
                catch (Exception exa)
                {
                    throw new Exception(exa.Message);
                }
            }
            Cn.Close();

            return dt;
        }
    }
}
