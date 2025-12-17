using MidasD.SrMidasD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidasD
{
    public partial class FrmCargos : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        SrMidasD.Usuario usuario;
        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2;
        bool bandera;
        DateTime fechaActualServidor;

        public FrmCargos(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
            this.usuario = usuario;
            btnPnlLista = new List<Control>() { btnBaja, btnEditar, btnNuevo, btnSalir, btnBuscar, pnlLista  };
            btnPnlLista2 = new List<Control>() { btnBaja, btnEditar };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar, pnlDatos };
            Util.btn_Mouse(new List<PictureBox>() { btnNuevo, btnEditar, btnBaja, 
                btnCancelar, btnGuardar, btnSalir, btnBuscar });
           
          
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);

            fechaActualServidor = servicio.fechaServidor();
            string mayo = ConfigurationManager.AppSettings.Get("1Mayo");
            if (mayo == "1")
            {
                if (fechaActualServidor.Month > 6)
                {
                    txtGestion.Text = fechaActualServidor.Year.ToString();
                }
                else
                {
                    txtGestion.Text = (fechaActualServidor.Year - 1).ToString();
                }
            }
            else
            {
                txtGestion.Text = fechaActualServidor.Year.ToString();
            }


            cargarUnidadEjecutora();
            cargarUnidadEjecutoraListar();
            cargarOficinasLista();

            btnNuevo.Enabled = false;
            btnNuevo.Image = Properties.Resources.new_inactive;

            //cargarSueldoMensual();
            //listarCargos();
        }


        private void cargarUnidadEjecutora()
        {
            cbxUnidadEjecutora.ValueMember = "idUnidadEjecutora";
            cbxUnidadEjecutora.DisplayMember = "descripcion";
            cbxUnidadEjecutora.DataSource = servicio.unidadEjecutoraListar(Util.header);
            cbxUnidadEjecutora.SelectedIndex = -1;
        }

        private void cargarUnidadEjecutoraListar()
        {
            cbxUnidadEjecutoraLista.ValueMember = "idUnidadEjecutora";
            cbxUnidadEjecutoraLista.DisplayMember = "descripcion";
            cbxUnidadEjecutoraLista.DataSource = servicio.unidadEjecutoraListar(Util.header);
            cbxUnidadEjecutoraLista.SelectedIndex = -1;
        }

        private void cargarOficinasLista()
        {
            try
            {
                cbxOficinaLista.ValueMember = "idOficina";
                cbxOficinaLista.DisplayMember = "oficina";
                cbxOficinaLista.DataSource = servicio.oficinaListarUnidadEjecutora(Util.header, Convert.ToInt32(cbxUnidadEjecutoraLista.SelectedValue.ToString()));
                cbxOficinaLista.SelectedIndex = -1;
            }
            catch
            { }
        }

        private void cargarSueldoMensual()
        {
            try
            {
                cbxSueldoMensual.ValueMember = "idSueldoMensual";
                cbxSueldoMensual.DisplayMember = "monto";
                cbxSueldoMensual.DataSource = servicio.paSueldosMensuales(Util.header,Convert.ToInt32(txtGestion.Text));
                cbxSueldoMensual.SelectedIndex = -1;
            }
            catch
            { }
        }

        private void listarEscalaSalarial()
        {
            try
            {
                cbxEscalaSalarial.ValueMember = "idEscalaSalarial";
                cbxEscalaSalarial.DisplayMember = "denominacion_Puesto";
                cbxEscalaSalarial.DataSource = servicio.escalaSalarialListar(Util.header);
                cbxEscalaSalarial.SelectedIndex = -1;
            }
            catch
            { }
        }

        private void cargarEscalaSalarial()
        {
            try
            {
                int idSueldoMensual = (int)servicio.sueldoMensualGet(Util.header, Convert.ToInt32(cbxSueldoMensual.SelectedValue.ToString())).idSueldoMensual;
                int idEscalaSalarial= servicio.escalaSalarialId(Util.header, idSueldoMensual).idEscalaSalarial;
                cbxEscalaSalarial.SelectedValue = idEscalaSalarial;
                if(chkDenominacion.Checked)
                {
                    txtCargoDenominacion.Text =servicio.escalaSalarialGet(Util.header, idEscalaSalarial).denominacion_Puesto.ToUpper();
                }
               
            }
            catch
            { }
        }

        private void listarCargos()
        {
            try
            {

                dgvLista.DataSource = servicio.cargoListarOficina(Util.header, Convert.ToInt32(cbxOficinaLista.SelectedValue.ToString()), Convert.ToInt32(txtGestion.Text));
                Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idCargo","idCargoOficina" });
                Utils.Wfa.setHeadersDGV(dgvLista);
                dgvLista.AutoResizeColumns();
                dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                if (dgvLista.RowCount < 1)
                {
                    btnEditar.Enabled = false;
                    btnBaja.Enabled = false;
                   
                    btnBaja.Image = Properties.Resources.delet_inactive;
                    btnEditar.Image = Properties.Resources.edit_inactive;
                }
                else
                {
                    btnEditar.Enabled = true;
                    btnBaja.Enabled = true;
                   
                    btnBaja.Image = Properties.Resources.delete;
                    btnEditar.Image = Properties.Resources.edti;
                }
            }
            catch { }
        }

        private void limpiar()
        {
            txtCargoDenominacion.Clear();
            cbxUnidadEjecutora.SelectedValue = -1;
            cbxOficina.SelectedValue = -1;
            cbxEscalaSalarial.SelectedValue = -1;
            cbxSueldoMensual.SelectedValue = -1;
            cbxTipoPersonal.SelectedValue = -1;
            txtCargoDescripcion.Clear();
            Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bandera = true;
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(true, btnPnlDatos);
            txtCargoDenominacion.Focus();
            cargarSueldoMensual();
            listarEscalaSalarial();
            try
            {
                cbxUnidadEjecutora.SelectedValue = Convert.ToInt32(cbxUnidadEjecutoraLista.SelectedValue.ToString());
                cbxOficina.SelectedValue = Convert.ToInt32(cbxOficinaLista.SelectedValue.ToString());

                cbxUnidadEjecutora.Enabled = false;
                cbxOficina.Enabled = false;
            }
            catch
            {
                cbxUnidadEjecutora.Enabled = true;
                cbxOficina.Enabled = true;
            }

            cbxEscalaSalarial.Focus();
           

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            DialogResult ResultadoDialogo = MessageBox.Show("El Cargo será dado de baja.\r¿Desea continuar?.", "::: Midas - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                int idCargo = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idCargo"].Value);
                servicio.menuEliminar(Util.header, idCargo);
                MessageBox.Show("El Cargo ha sido dado de baja.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Util.pnlListaActivar(true, btnPnlLista);
                Util.pnlListaActivar(false, btnPnlDatos);
                limpiar();
                listarCargos();
            }
        }

        private void cargarCampos()
        {
            int idCargo = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idCargo"].Value);
            SrMidasD.Cargo cargoDatos = servicio.cargoGet(Util.header, idCargo);
            txtCargoDescripcion.Text = cargoDatos.descripcion_Puesto;
            txtCargoDenominacion.Text = cargoDatos.denominacion_Puesto;
            cbxUnidadEjecutora.SelectedValue = Convert.ToInt32(cbxUnidadEjecutoraLista.SelectedValue.ToString());
            cbxOficina.SelectedValue = Convert.ToInt32(cbxOficinaLista.SelectedValue.ToString());
            cbxEscalaSalarial.SelectedValue = cargoDatos.idEscalaSalarial;
            cbxSueldoMensual.SelectedValue = servicio.escalaSalarialGet(Util.header,(int)cargoDatos.idEscalaSalarial).idSueldoMensual;
            cbxTipoPersonal.SelectedItem = cargoDatos.tipo_Personal;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cargarSueldoMensual();
            listarEscalaSalarial();
            cargarCampos();
            bandera = false;
            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(true, btnPnlDatos);
            txtCargoDenominacion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (bandera)
            {
                if (!validar())
                {
                    MessageBox.Show("Todos los campos deben estar lleno.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    guardar();
                    MessageBox.Show("El Cargo ha sido registrado.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (!validar())
                {
                    MessageBox.Show("Todos los campos lleno.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    editar();
                    MessageBox.Show("El Cargo ha sido editado.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        public void cancelar()
        {
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            limpiar();
        }

        private bool validar()
        {
            bool aux = true;
            erpMenu.SetError(txtCargoDenominacion, "");
            erpMenu.SetError(txtCargoDescripcion, "");
            if ((String.IsNullOrWhiteSpace(txtCargoDenominacion.Text))) { erpMenu.SetError(txtCargoDenominacion, "Debe introducir una Denominacion"); aux = false; }
            if ((String.IsNullOrWhiteSpace(txtCargoDescripcion.Text))) { erpMenu.SetError(txtCargoDescripcion, "Debe introducir una Descripcion"); aux = false; }
            return aux;
        }

        private void activarMenu(int idMenu)
        {
            servicio.menuActivar(Util.header, idMenu);
            listarCargos();
            limpiar();
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
        }

        private void guardar()
        {
            SrMidasD.Cargo cargo = new SrMidasD.Cargo();
            cargo.denominacion_Puesto = txtCargoDenominacion.Text.Trim();
            cargo.descripcion_Puesto = txtCargoDescripcion.Text.Trim();
            cargo.tipo_Personal =cbxTipoPersonal.SelectedItem.ToString();
            cargo.idEscalaSalarial = Convert.ToInt32(cbxEscalaSalarial.SelectedValue.ToString());
            cargo.sigla = "--";
            cargo.usuarioRegistro = usuario.nombre_Usuario;
            cargo.fechaRegistro = servicio.fechaServidor();
            cargo.registroActivo = true;
  
            int idCargo=servicio.cargoInsertar(Util.header, cargo);

            SrMidasD.CargoOficina cargoOficina = new SrMidasD.CargoOficina();
            cargoOficina.idCargo = idCargo;
            cargoOficina.idOficina = Convert.ToInt32(cbxOficina.SelectedValue.ToString());
            cargoOficina.usuarioRegistro = usuario.nombre_Usuario;
            cargoOficina.fechaRegistro = servicio.fechaServidor();
            cargoOficina.registroActivo = true;

            servicio.cargoOficinaInsertar(Util.header, cargoOficina);

            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            limpiar();
            listarCargos();
        }

        private void editar()
        {
            int idCargo = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idCargo"].Value);
            SrMidasD.Cargo cargo = servicio.cargoGet(Util.header, idCargo);
            cargo.denominacion_Puesto = txtCargoDenominacion.Text.Trim();
            cargo.descripcion_Puesto = txtCargoDescripcion.Text.Trim();
            cargo.tipo_Personal = cbxTipoPersonal.SelectedItem.ToString();
            cargo.idEscalaSalarial = Convert.ToInt32(cbxEscalaSalarial.SelectedValue.ToString());
            cargo.sigla = "--";
            cargo.usuarioRegistro = usuario.nombre_Usuario;
            cargo.fechaRegistro = servicio.fechaServidor();
            cargo.registroActivo = true;

            servicio.cargoEditar(Util.header, cargo);

            int idCargoOficina = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idCargoOficina"].Value);
            SrMidasD.CargoOficina cargoOficina = servicio.cargoOficinaGet(Util.header, idCargoOficina);
            cargoOficina.idCargo = idCargo;
            cargoOficina.idOficina = Convert.ToInt32(cbxOficina.SelectedValue.ToString());
            cargoOficina.usuarioRegistro = usuario.nombre_Usuario;
            cargoOficina.fechaRegistro = servicio.fechaServidor();
            cargoOficina.registroActivo = true;

            servicio.cargoOficinaEditar(Util.header, cargoOficina);

            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            limpiar();
            listarCargos();
        }

        private void dgvLista_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private void cbxUnidadEjecutora_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbxOficina.ValueMember = "idOficina";
                cbxOficina.DisplayMember = "oficina";
                cbxOficina.DataSource = servicio.oficinaListarUnidadEjecutora(Util.header, Convert.ToInt32(cbxUnidadEjecutora.SelectedValue.ToString()));
                cbxOficina.DropDownWidth = widthComboBoxCargos(cbxOficina);
                cbxOficina.SelectedIndex = -1;
                
            }
            catch
            {
                cbxOficina.ValueMember = "idOficina";
                cbxOficina.DisplayMember = "oficina";
                cbxOficina.DataSource = null;
                cbxOficina.SelectedIndex = -1;
            }
        }


        //Redimencionar Combo Box Cargos
        public static int widthComboBoxCargos(ComboBox cbx)
        {
            int num = 0;
            int preferredWidth = 0;
            Label label = new Label
            {
                Font = new Font(cbx.Font.FontFamily, cbx.Font.Size, cbx.Font.Style, GraphicsUnit.Point, 0)
            };
            foreach (object obj2 in cbx.Items)
            {
                label.Text = ((paListaOficinaUnidadEjecutora_Result)obj2).oficina.Trim();
                preferredWidth = label.PreferredWidth;
                if (preferredWidth > num)
                {
                    num = preferredWidth;
                }
            }
            return (num + 20);
        }

        private void btnBuscarOficina_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmSeleccionarOficina(Convert.ToInt32(cbxUnidadEjecutoraLista.SelectedValue.ToString())).ShowDialog();
                insertarOficinaCbx(FrmSeleccionarOficina.oficina);
                btnNuevo.Enabled = true;
                btnNuevo.Image = Properties.Resources._new;
            }
            catch
            {
                btnNuevo.Enabled = false;
                btnNuevo.Image = Properties.Resources.new_inactive;
            }
        }

        private void insertarOficinaCbx(SrMidasD.Oficina oficina)
        {
            try
            {
                cbxOficinaLista.SelectedValue = oficina.idOficina;
                txtOficinaLiteral.Text = oficina.oficina1;
                //erpError.Clear();
                listarCargos();
                //cbxCargo.Focus();
                //cbxCargo.DroppedDown = true;
            }
            catch { }
        }

        private void cbxUnidadEjecutoraLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbxOficinaLista.ValueMember = "idOficina";
                cbxOficinaLista.DisplayMember = "oficina";
                cbxOficinaLista.DataSource = servicio.oficinaListarUnidadEjecutora(Util.header, Convert.ToInt32(cbxUnidadEjecutoraLista.SelectedValue.ToString()));
                cbxOficinaLista.SelectedIndex = -1;
            }
            catch
            {
                cbxOficinaLista.ValueMember = "idOficina";
                cbxOficinaLista.DisplayMember = "oficina";
                cbxOficinaLista.DataSource = null;
                cbxOficinaLista.SelectedIndex = -1;
            }
        }

        private void txtGestion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyNumbers(sender, e);

            string nombre = ((TextBox)sender).Name.ToString();
           

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                listarCargos();
            }
        }

        private void cbxSueldoMensual_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarEscalaSalarial();
        }

        private void dgvLista_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            cargarSueldoMensual();
            listarEscalaSalarial();
            cargarCampos();
            bandera = false;
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(true, btnPnlDatos);
            txtCargoDenominacion.Focus();
        }

        private void txtGestion_TextChanged(object sender, EventArgs e)
        {
            cargarSueldoMensual();
            listarEscalaSalarial();
        }

        private void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            cancelar();

            cargarUnidadEjecutora();
            cargarUnidadEjecutoraListar();
            cargarOficinasLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarCargos();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                listarCargos();
            }
        }
    }
}
