﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Sol_Minimarket.Entidades;
using Sol_Minimarket.Datos;


namespace Sol_Minimarket.Negocio
{
    public class N_Categorias
    {
        public static DataTable Listado_ca(String cTexto) 
        {
            D_Categorias Datos = new D_Categorias();
            return Datos.Listado_ca(cTexto);
        }
        public static string Guardar_ca(int nOpcion, E_Categorias oCa)
        {
            D_Categorias Datos = new D_Categorias();
            return Datos.Guardar_ca(nOpcion, oCa);
        }
        public static string Eliminar_ca(int Codigo_ca)
        {
            D_Categorias Datos = new D_Categorias();
            return Datos.Eliminar_ca(Codigo_ca);
        }

    }
}
