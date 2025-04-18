﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sol_Minimarket.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;
        private static Conexion Con = null;

        private Conexion()
        {
            this.Base = "BD_Minimarket";
            this.Servidor = "DESKTOP-KIDS6OC\\SOLUSYSTEMS";
            this.Usuario = "Sistemas";
            this.Clave = "Solusystems2024*.";
            this.Seguridad = false;
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor + "Database=" + this.Base + ";";
                if (this.Seguridad)
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security = SSPI";
                }
                else 
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "User ID="+this.Usuario+"; Password=" + this.Clave;
                }
            }
            catch(Exception ex) 
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion getInsstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
