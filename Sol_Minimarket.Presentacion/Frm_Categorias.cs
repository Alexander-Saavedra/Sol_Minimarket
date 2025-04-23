using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
using Sol_Minimarket.Entidades;
=======
>>>>>>> 4fec03b7ff8fdc59253cf8a4e9a51add0cd9b660
using Sol_Minimarket.Negocio;

namespace Sol_Minimarket.Presentacion
{
    public partial class Frm_Categorias : Form
    {
        public Frm_Categorias()
        {
            InitializeComponent();
        }
<<<<<<< HEAD
        #region "Mis variables"
        int EstadoGuarda = 0; // Sin ninguna accion
        #endregion
=======
>>>>>>> 4fec03b7ff8fdc59253cf8a4e9a51add0cd9b660
        #region "Mis metodos"
        private void  Formato_ca()
        {
<<<<<<< HEAD
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "codigo_ca";
            Dgv_principal.Columns[1].Width = 300;
            Dgv_principal.Columns[1].HeaderText = "categoria";
=======
            Dgv_principal.Columns[0].Widht = 100;
            Dgv_principal.Columns[0].HeaderText = "Coidgo_ca";
            Dgv_principal.Columns[1].Widht = 300;
            Dgv_principal.Columns[1].HeaderText = "Categoria";
>>>>>>> 4fec03b7ff8fdc59253cf8a4e9a51add0cd9b660
        }
        private void Listado_ca(String cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Categorias.Listado_ca(cTexto);
                this.Formato_ca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Estado_BotonesPrincipales(bool lEstado)
        {
            this.Btn_nuevo.Enabled = lEstado;
            this.Btn_actualizar.Enabled = lEstado;
            this.Btn_eliminar.Enabled = lEstado;
            this.Btn_reporte.Enabled = lEstado;
            this.Btn_salir.Enabled = lEstado;
        }
        private void Estado_Botonesprocesos(bool lEstado)
        {

        }
        #endregion
        private void Frm_categorias_load(Object sender, EventArgs e)
        {
            this.Listado_ca("%");
        }
<<<<<<< HEAD

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if(Txt_descripcion_ca.Text == String.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //se procede a registrar la informacion
            {

            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            EstadoGuarda = 1; //Nuevos registros
            this.Estado_BotonesPrincipales(false);
            Txt_descripcion_ca.Text = "";
            Tbp_principal.SelectedIndex = 1;
            Txt_descripcion_ca.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            EstadoGuarda = 2; //Actualizar registros
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
=======
>>>>>>> 4fec03b7ff8fdc59253cf8a4e9a51add0cd9b660
    }
}
