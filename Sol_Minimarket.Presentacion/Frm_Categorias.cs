using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sol_Minimarket.Negocio;

namespace Sol_Minimarket.Presentacion
{
    public partial class Frm_Categorias : Form
    {
        public Frm_Categorias()
        {
            InitializeComponent();
        }
        #region "Mis metodos"
        private void  Formato_ca()
        {
            Dgv_principal.Columns[0].Widht = 100;
            Dgv_principal.Columns[0].HeaderText = "Coidgo_ca";
            Dgv_principal.Columns[1].Widht = 300;
            Dgv_principal.Columns[1].HeaderText = "Categoria";
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
        #endregion
        private void Frm_categorias_load(Object sender, EventArgs e)
        {
            this.Listado_ca("%");
        }
    }
}
