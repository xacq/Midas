using MidasD.SrMidasD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidasD
{
    public partial class FrmEstadoFianzasActuales : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        //public static SrMidasD.Articulo articulo;

        public int idUnidadEjecutora;
        SrMidasD.Usuario usuario;

        public FrmEstadoFianzasActuales(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            this.usuario = usuario;



            cbxUnidadEjecutora.ValueMember = "idUnidadEjecutora";
            cbxUnidadEjecutora.DisplayMember = "descripcion";
            cbxUnidadEjecutora.DataSource = servicio.unidadEjecutoraListar(Util.header);
            cbxUnidadEjecutora.SelectedIndex = 0;
            cbxUnidadEjecutora.DropDownWidth = widthComboBox(cbxUnidadEjecutora);


            idUnidadEjecutora = Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString());
           

            listar();
          
        }


        public static int widthComboBox(ComboBox cbx)
        {
            int num = 0;
            int preferredWidth = 0;
            Label label = new Label
            {
                Font = new Font(cbx.Font.FontFamily, cbx.Font.Size, cbx.Font.Style, GraphicsUnit.Point, 0)
            };
            foreach (object obj2 in cbx.Items)
            {
                label.Text = ((UnidadEjecutora)obj2).descripcion.Trim();
                preferredWidth = label.PreferredWidth;
                if (preferredWidth > num)
                {
                    num = preferredWidth;
                }
            }
            return (num + 20);
        }

        private void listar()
        {

            dgvLista.DataSource = servicio.paListarFianzasTipoFianzaGestionUnidadEjecutoraHabilitado(Util.header, txtParametro.Text, 2, DateTime.Now.Year, Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()));

            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idFianza" });
            datosLista();
     
            dgvLista.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvListaEntradas_DataBindingComplete);
        }

        public void datosLista()
        {
            dgvLista.Columns["cargo"].DisplayIndex = 01;
            dgvLista.Columns["apellidos_Y_Nombres"].DisplayIndex = 02;
            dgvLista.Columns["ci"].DisplayIndex = 03;
            dgvLista.Columns["item"].DisplayIndex = 04;
            dgvLista.Columns["h_b"].DisplayIndex = 05;
            dgvLista.Columns["estado_Cuenta_Gestion_Pasada"].DisplayIndex = 06;
            dgvLista.Columns["enero"].DisplayIndex = 07;
            dgvLista.Columns["febrero"].DisplayIndex = 08;
            dgvLista.Columns["marzo"].DisplayIndex = 09;
            dgvLista.Columns["abril"].DisplayIndex = 10;
            dgvLista.Columns["mayo"].DisplayIndex = 11;
            dgvLista.Columns["junio"].DisplayIndex = 12;
            dgvLista.Columns["julio"].DisplayIndex = 13;
            dgvLista.Columns["agosto"].DisplayIndex = 14;
            dgvLista.Columns["septiembre"].DisplayIndex = 15;
            dgvLista.Columns["octubre"].DisplayIndex = 16;
            dgvLista.Columns["noviembre"].DisplayIndex = 17;
            dgvLista.Columns["diciembre"].DisplayIndex = 18;
            dgvLista.Columns["total_Descuento"].DisplayIndex = 19;
            dgvLista.Columns["total_Descontar"].DisplayIndex = 20;


            Utils.Wfa.setHeadersDGV(dgvLista);  
            //dgvLista.Columns["unidad"].HeaderText = "Unidad";
            //dgvLista.Columns["Cantidad_Actual"].HeaderText = "Cantidad Actual";


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //articulo = null;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = servicio.paListarFianzasTipoFianzaGestionUnidadEjecutoraHabilitado(Util.header, txtParametro.Text, 2, DateTime.Now.Year, Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()));
            datosLista();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar.PerformClick();
            }
        }

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAceptar.PerformClick();
        }

        private void cbxTienda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idUnidadEjecutora = Convert.ToInt32(cbxUnidadEjecutora.SelectedValue);
            listar();
        }

        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private void dgvListaEntradas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow item in dgvLista.Rows)
            {

                int totalDescuento = Convert.ToInt32(item.Cells["total_Descuento"].Value);
                int totalDescontar = Convert.ToInt32(item.Cells["total_Descontar"].Value);


                int index = item.Index;


                if (totalDescuento >= totalDescontar)
                {
                    Util.pintarDatagridwiewIndex(dgvLista, index, "White", "Green");
                }
                else
                {
                    Util.pintarDatagridwiewIndex(dgvLista, index, "White", "Black");
                } 

                dgvLista.ClearSelection();
            }
        }

        private void FrmEstadoFianzasActuales_Load(object sender, EventArgs e)
        {
            listar();
        }
    }
}
