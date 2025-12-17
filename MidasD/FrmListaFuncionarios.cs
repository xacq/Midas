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
    public partial class FrmListaFuncionarios : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        public static SrMidasD.Fianza Fianza;
        private bool esContabilidad = false;


        public FrmListaFuncionarios(bool esContabilidad,int idTipoFianza)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            this.esContabilidad = esContabilidad;
           
            cargarUnidadEjecutora();
            listar();
        }

        private void listar()
        {
            if (esContabilidad)
            {
                //dgvLista.DataSource = servicio.pa(Util.header, Utils.Utils.unaccented(txtParametro.Text.Trim().ToLower()));
            }
            else
            {
                dgvLista.DataSource = servicio.pafuncionarioFianzaActualBuscar(Util.header, Utils.Utils.unaccented(txtParametro.Text.Trim().ToLower()),Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()),2);
                dgvLista.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvListaEntradas_DataBindingComplete);
            }
            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idPersonal","idPartida", "idGrupo", "idSubGrupo","usuarioRegistro", "fechaRegistro", "registroActivo", "idUnidad" });
            Utils.Wfa.positionHeadersDGV(dgvLista, new List<string>() { "descripcion", "grupo", "Sub_Grupo",});
            Utils.Wfa.setHeadersDGV(dgvLista);
            if (dgvLista.Rows.Count == 0) 
            btnAceptar.Enabled = false;
            else btnAceptar.Enabled = true;

          
        }

        //Listar las Unidades Encargadas
        private void cargarUnidadEjecutora()
        {
            cbxUnidadEjecutora.ValueMember = "idUnidadEjecutora";
            cbxUnidadEjecutora.DisplayMember = "descripcion";
            cbxUnidadEjecutora.DataSource = servicio.unidadEjecutoraListar(Util.header);
            cbxUnidadEjecutora.SelectedIndex = 0;
        }

        private void dgvListaEntradas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dgvLista.Rows)
                {

                    int saldo = Convert.ToInt32(item.Cells["Cantidad_Actual"].Value);
               

                    int index = item.Index;

                    if (saldo > 0)
                    {
                        Util.pintarDatagridwiewIndex(dgvLista, index, "White", "Green");
                    }
                    else
                    {
                        Util.pintarDatagridwiewIndex(dgvLista, index, "White", "Red");
                    }

                    dgvLista.ClearSelection();

                }
            }
            catch { }
           
        }

        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Fianza = servicio.fianzaGet(Util.header, Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idFianza"].Value));
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Fianza = null;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
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

        private void cbxUnidadEjecutora_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listar();
        }
    }
}
