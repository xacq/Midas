using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
//using MidasD.Reportes;

namespace MidasD
{
    public partial class FrmSeleccionarOficina : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        public static SrMidasD.Oficina oficina;
        int idUnidadEjecutora;

        public FrmSeleccionarOficina(int idUnidadEjecutora)
        {
            InitializeComponent();
            this.idUnidadEjecutora = idUnidadEjecutora;
            servicio = new SrMidasD.MidasDServiceClient();

            listar();
        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            oficina = null;
            this.Close();
        }

        private void listar()
        {
            dgvListaOficinas.DataSource = servicio.paoficinaBuscar(Util.header, Utils.Utils.unaccented(txtParametro.Text.Trim().ToLower()),idUnidadEjecutora);
            Utils.Wfa.hideHeadersDGV(dgvListaOficinas, new List<string>() {
                "idOficina"});
            Utils.Wfa.setHeadersDGV(dgvListaOficinas);
            dgvListaOficinas.AutoResizeColumns();
            dgvListaOficinas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dgvListaOficinas.Rows.Count == 0) btnAceptar.Enabled = false;
            else btnAceptar.Enabled = true;

        }

      

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            oficina = servicio.oficinaGet(Util.header, Convert.ToInt32(dgvListaOficinas.Rows[dgvListaOficinas.CurrentRow.Index].Cells["idOficina"].Value));
            this.Close();
        }

        private void FrmSeleccionarOficina_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void cbxUnidadEjecutora_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender, e);
            }
        }

        //Insertamos numeracion
        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private void dgvListaOficinas_DoubleClick(object sender, EventArgs e)
        {
            oficina = servicio.oficinaGet(Util.header, Convert.ToInt32(dgvListaOficinas.Rows[dgvListaOficinas.CurrentRow.Index].Cells["idOficina"].Value));
            this.Close();
        }
    }
}
