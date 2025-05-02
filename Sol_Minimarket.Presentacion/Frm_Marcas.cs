using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sol_Minimarket.Datos;
using Sol_Minimarket.Entidades;
using Sol_Minimarket.Negocio;

namespace Sol_Minimarket.Presentacion
{
    public partial class Frm_Marcas : Form
    {
        public Frm_Marcas()
        {
            InitializeComponent();
        }
        #region "Mis variables"
        int Codigo_ma = 0;
        int EstadoGuarda = 0; // Sin ninguna accion
        #endregion


        #region "Mis metodos"
        private void Formato_ma()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "codigo_ma";
            Dgv_principal.Columns[1].Width = 300;
            Dgv_principal.Columns[1].HeaderText = "marcas";
        }
        private void Listado_ma(String cTexto)
        {
            try
            {
                Dgv_principal.DataSource = Conexion.ExtraeDatos("exec USP_Listado_ma '%'");
                this.Formato_ma();
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
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible = lEstado;
            this.Btn_retornar.Visible = !lEstado;
        }
        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ma"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ma = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["Codigo_ma"].Value);  
                Txt_descripcion_ma.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_ma"].Value);
            }
        }
        #endregion
        private void Frm_Marcas_load(Object sender, EventArgs e)
        {
            this.Listado_ma("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_ma.Text == String.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //se procede a registrar la informacion
            {
               
                try
                {

           
                    if (Conexion.EjecutarPro("USP_Guardar_ma", 1, 0, Txt_descripcion_ma.Text.Trim()))
                    {
                       this.Listado_ma("%");
                        MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EstadoGuarda = 1; //Sin ninguna accion
                        this.Estado_BotonesPrincipales(true);
                        this.Estado_Botonesprocesos(false);
                        Txt_descripcion_ma.Text = "";
                        Txt_descripcion_ma.ReadOnly = true;
                        Tbp_principal.SelectedIndex = 0;
                        this.Codigo_ma = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Registro Guardado", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            EstadoGuarda = 1; //Nuevos registros
            this.Estado_BotonesPrincipales(false);
            this.Estado_Botonesprocesos(true);
            Txt_descripcion_ma.Text = "";
            Txt_descripcion_ma.ReadOnly = false;
            Tbp_principal.SelectedIndex = 1;
            Txt_descripcion_ma.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            EstadoGuarda = 2; //Actualizar registros
            this.Estado_BotonesPrincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Selecciona_item();
            Tbp_principal.SelectedIndex = 1;
            Txt_descripcion_ma.ReadOnly = false;
            Txt_descripcion_ma.Focus();

        }
        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            EstadoGuarda = 0;   //Sin niniguna accion
            this.Codigo_ma = 0;
            Txt_descripcion_ma.Text = "";
            Txt_descripcion_ma.ReadOnly = true;
            this.Estado_BotonesPrincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbp_principal.SelectedIndex = 0;
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.Selecciona_item();
            this.Estado_Botonesprocesos(false);
            Tbp_principal.SelectedIndex = 1;
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbp_principal.SelectedIndex = 0;
            this.Codigo_ma = 0;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ma"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Estas seguro de eliminar el registro que seleccionaste?", "Aviso del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if(Opcion==DialogResult.Yes)
                {
                    try
                    {

                    this.Codigo_ma = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ma"].Value);
                    if(Conexion.EjecutarPro("USP_Eliminar_ma", this.Codigo_ma))
                    {
                        MessageBox.Show("Registro eliminado", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Listado_ma("%");
                        this.Codigo_ma = 0;
                    }
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    }

                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_ma(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            //Reportes.Frm_Rpt_Marcas oRpt1 = new Reportes.Frm_Rpt_Categorias();
            //oRpt1.Txt_p1.Text = Txt_buscar.Text;
            //oRpt1.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {

        }

        private void lbl_buscar_Click(object sender, EventArgs e)
        {

        }
    }
}