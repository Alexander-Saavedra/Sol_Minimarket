using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_Minimarket.Presentacion.Reportes
{
    public partial class Frm_Rpt_Marcas : Form
    {
        public Frm_Rpt_Marcas()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Marcas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet_MiniMarket.USP_Listado_ma' Puede moverla o quitarla según sea necesario.
            this.USP_Listado_maTableAdapter.Fill(this.DataSet_MiniMarket.USP_Listado_ma);
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
