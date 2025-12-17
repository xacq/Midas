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
    public partial class FrmUsuario : Form
    {     
        public int idPersona;

        public SrMidasD.Usuario usuario;
        SrMidasD.MidasDServiceClient servicio;
        public SrMidasD.Persona persona;

        List<Control> btnPnlLista, btnPnlDatos, btnPnlLista2, btnPnlLista3;
        bool bandera;
        public FrmUsuario(SrMidasD.Usuario usuario)
        {
            InitializeComponent();

            this.usuario = usuario;
           
            servicio = new SrMidasD.MidasDServiceClient();
           
            btnPnlLista = new List<Control>() { btnNuevo, btnBuscar, txtParametro };
            btnPnlLista2 = new List<Control>() { btnRestablecerClave, btnBaja, btnEditar };
            btnPnlLista3 = new List<Control>() { btnSalir, pnlLista };
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar, pnlDatos};
            Util.btn_Mouse(new List<PictureBox>() { btnNuevo, btnEditar, btnBaja, 
            btnRestablecerClave, btnCancelar, btnGuardar, btnSalir, btnBuscar,btnBuscarPersonas });
            listar();
           
            pnlPersonas.Visible = false;

        }

        private void listar()
        {
            dgvLista.DataSource = servicio.usuarioListarDatosUsuario(Util.header);
            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idUsuario", "clave", "paterno", 
                "materno","nombres", "registroActivo", "usuarioRegistro","idLugarExpedido","idPersona","idTipoDocumento","sexo","estado_Civil"});

            dgvLista.AutoResizeColumns();
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvLista.Columns["nombre_Usuario"].DisplayIndex = 0;
            dgvLista.Columns["nombre_Completo"].DisplayIndex = 1;
            dgvLista.Columns["numero_documento"].DisplayIndex = 2;
            dgvLista.Columns["domicilio"].DisplayIndex = 3;
            dgvLista.Columns["fecha_Nacimiento"].DisplayIndex = 4;

            
            Utils.Wfa.setHeadersDGV(dgvLista);

            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlPersonas.Visible = true;
            listarPersonas();
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlDatos);

            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cargarCampos();
            bandera = false;
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
            txtUsuario.Focus();
            //formarUsuario_Leave();
        }

        private void formarUsuario_Leave()
        {
            if ((!string.IsNullOrEmpty(lblNombre.Text) && !string.IsNullOrEmpty(lblPaterno.Text)) ||
                (!string.IsNullOrEmpty(lblNombre.Text) && !string.IsNullOrEmpty(lblMaterno.Text)))
            {
                String recomendacion = string.Empty, iniciales = string.Empty, apellido = string.Empty;
                int i = 0;
                bool nuevo = true;
                txtUsuario.Text = string.Empty;
                foreach (string inicial in lblNombre.Text.Trim().ToLower().Split(' '))
                    iniciales += inicial.Substring(0, 1);
                apellido = string.IsNullOrEmpty(lblPaterno.Text) ? lblMaterno.Text : lblPaterno.Text;
                do
                {
                    if (i > 0) iniciales = iniciales.Insert(i, lblNombre.Text.ToLower().Substring(i, 1));
                    recomendacion = iniciales + "" + apellido.Trim().ToLower();
                    txtUsuario.Text = recomendacion;
                    nuevo = servicio.usuarioValidarNuevo(Util.header,idPersona, recomendacion) != null;
                    i++;
                }
                while ((nuevo && bandera) || (!bandera && nuevo &&
                    recomendacion != dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["nombre_Usuario"].Value.ToString()));
            }
        }

        private void Limpiar()
        {
            lblNombre.ResetText();
            lblPaterno.ResetText();
            lblMaterno.ResetText();
            lblDocumento.ResetText();

            lblUsuario.ResetText();
            txtUsuario.Clear();


        }

        private void cargarCampos()
        {
            int idUsuario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idUsuario"].Value);
            SrMidasD.Usuario usuarioDatos = servicio.usuarioGet(Util.header, idUsuario);
            SrMidasD.Persona personaDatos = servicio.personaGet(Util.header, usuarioDatos.idPersona);
            SrMidasD.TipoDocumento tipoDocumento = servicio.tipoDocumentoGet(Util.header,Convert.ToInt32(personaDatos.idTipoDocumento.ToString()));
            
         
            lblNombre.Text = personaDatos.nombres;
            lblPaterno.Text = personaDatos.paterno;
            lblMaterno.Text = personaDatos.materno;

            lblUsuario.Text=usuarioDatos.nombre_Usuario;
           

            lblDocumento.Text = tipoDocumento.descripcion + " -" + personaDatos.numero_Documento;
            txtUsuario.Text = usuarioDatos.nombre_Usuario;

            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");
        }

        private bool validar()
        {
            bool aux = true;
            erpUsuario.SetError(txtUsuario, "");
           
            if ((String.IsNullOrWhiteSpace(txtUsuario.Text))) { erpUsuario.SetError(txtUsuario, "Debe introducir un Usuario"); aux = false; }
           
            return aux;
        }

        private void activarUsuario(int idUsuario)
        {
            servicio.usuarioActivar(Util.header, idUsuario);

            listar();
            Util.pnlListaActivar(true, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bandera)
            {
                if (!validar())
                {
                    MessageBox.Show("Todos los campos deben estar llenos.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Verificar si existe
                    SrMidasD.Usuario usuarioDatos = servicio.usuarioValidarNuevo(Util.header, idPersona, txtUsuario.Text.Trim());
                    
             
                    if (usuarioDatos != null)
                    {
                        string nombre =  servicio.personaGet(Util.header,idPersona).nombres;
                        string paterno = servicio.personaGet(Util.header, idPersona).paterno;
                        string materno = servicio.personaGet(Util.header, idPersona).materno;
                        string documento = servicio.personaGet(Util.header, idPersona).numero_Documento;

                        if (Convert.ToBoolean(usuarioDatos.registroActivo))
                        {
                            MessageBox.Show("El usuario ya está registrado.\rNombre: " + nombre + ".\rApellido Paterno: " + paterno + ".\rApelllido Materno: " + materno + ".\rDoc. Identidad: " + documento + ".", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DialogResult ResultadoDialogo = MessageBox.Show("El usuario está dado de baja. ¿Desea activarlo?.\rNombre: " + nombre + ".\rApellido Paterno: " + paterno + ".\rApelllido Materno: " + materno + ".\rDoc. Identidad: " + documento + ".", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ResultadoDialogo == DialogResult.Yes)
                            {
                                //Activar Usuario
                                activarUsuario(usuarioDatos.idUsuario);
                                MessageBox.Show("El Usuario ha sido activado.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        guardar();
                        Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                        MessageBox.Show("El Usuario ha sido registrado.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (!validar())
                {
                    MessageBox.Show("Todos los campos deben estar llenos.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int idUsuario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idUsuario"].Value);
                    SrMidasD.Usuario usuarioDatos = servicio.usuarioGet(Util.header, idUsuario);
                    SrMidasD.Persona personaDatos = servicio.personaGet(Util.header, usuarioDatos.idPersona);

                    
                        usuarioDatos = servicio.usuarioValidarUsuario(Util.header,txtUsuario.Text.Trim());
                        

                        if (usuarioDatos != null && usuarioDatos.idUsuario!=idUsuario)
                        {
                            personaDatos = servicio.personaGet(Util.header, usuarioDatos.idPersona);
                            string nombre = personaDatos.nombres;
                            string paterno = personaDatos.paterno;
                            string materno = personaDatos.materno;
                            string documento = personaDatos.numero_Documento;

                            if (Convert.ToBoolean(usuarioDatos.registroActivo))
                            {
                                MessageBox.Show("El usuario ya está registrado.\rNombre: " + nombre + ".\rApellido Paterno: " + paterno + ".\rApelllido Materno: " + materno + ".\rDoc. Identidad: " + documento + ".", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                           
                        }
                        else
                        {
                            editar();
                        Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
                        MessageBox.Show("El Usuario ha sido editado.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }                    
                }
            }
        }

        private void guardar()
        {
            string clave = Utils.Utils.Encrypt("hola123");

            SrMidasD.Usuario usuario = new SrMidasD.Usuario();

            usuario.nombre_Usuario = txtUsuario.Text.Trim();
            usuario.clave = clave;
           
            usuario.idPersona = idPersona;
            usuario.usuarioRegistro = this.usuario.nombre_Usuario;
            usuario.idCodigoZeus = 6;
            usuario.registroActivo = true;
           
            servicio.usuarioInsertar(Util.header, usuario);
            listar();

            Limpiar();
        }

        private void editar()
        {
            int idUsuario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idUsuario"].Value);
            SrMidasD.Usuario usuario = servicio.usuarioGet(Util.header, idUsuario);
            usuario.nombre_Usuario = txtUsuario.Text.Trim();
            usuario.idPersona = usuario.idPersona;
           
            servicio.usuarioEditar(Util.header, usuario);
     
            listar();
          
            Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        public void cancelar()
        {
            listar();
            if (dgvLista.Rows.Count == 0) Util.pnlListaActivar(false, btnPnlLista2);
            Util.pintarDatagridwiew(dgvLista, "Black", "Gray");
            Limpiar();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            DialogResult ResultadoDialogo = MessageBox.Show("El ususario será dado de baja.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                int idUsuario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idUsuario"].Value);
                servicio.usuarioEliminar(Util.header, idUsuario);
                MessageBox.Show("El Usuario ha sido dado de baja.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
                Limpiar();
            }
        }

        private void btnRestablecerClave_Click(object sender, EventArgs e)
        {
            DialogResult ResultadoDialogo = MessageBox.Show("Esta seguro que desea reestablecer la clave.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ResultadoDialogo == DialogResult.Yes)
            {
                int idUsuario = Convert.ToInt32(dgvLista.Rows[dgvLista.CurrentRow.Index].Cells["idUsuario"].Value);
                string clave = Utils.Utils.Encrypt("hola123");
                servicio.usuarioCambiarClave(Util.header, idUsuario, clave);
                MessageBox.Show("La clave ha sido restablecida.", "::: MidasD - Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
                Limpiar();
            }
        }

        private void formarUsuarioPersona_Leave()
        {
            try
            {
                cargarCamposPersona(idPersona);

                if ((!string.IsNullOrEmpty(lblNombre.Text) && !string.IsNullOrEmpty(lblPaterno.Text)) ||
                    (!string.IsNullOrEmpty(lblNombre.Text) && !string.IsNullOrEmpty(lblPaterno.Text)))
                {
                    String recomendacion = string.Empty, iniciales = string.Empty, apellido = string.Empty;
                    int i = 0;
                    bool nuevo = true;
                    txtUsuario.Text = string.Empty;
                    foreach (string inicial in lblNombre.Text.Trim().ToLower().Split(' '))
                        iniciales += inicial.Substring(0, 1);
                    apellido = string.IsNullOrEmpty(lblPaterno.Text) ? lblMaterno.Text : lblPaterno.Text;
                    do
                    {
                        if (i > 0) iniciales = iniciales.Insert(i, lblNombre.Text.ToLower().Substring(i, 1));
                        recomendacion = iniciales + "" + apellido.Trim().ToLower();
                        txtUsuario.Text = recomendacion;
                        nuevo = servicio.usuarioValidarNuevo(Util.header, idPersona, recomendacion) != null;
                        i++;
                    }
                    while ((nuevo && bandera) || (!bandera && nuevo));
                    txtUsuario.Text = recomendacion;
                }

                Util.pnlListaActivar(false, btnPnlLista);
                Util.pnlListaActivar(true, btnPnlDatos);
                Util.pnlListaActivar(false, btnPnlLista2);
                Util.pnlListaActivar(false, btnPnlLista3);

            }
            catch
            {
                SrMidasD.Persona personaDatos = servicio.personaGet(Util.header, idPersona);
                SrMidasD.Usuario usuarioDatos = servicio.usuarioPersonaGet(Util.header, personaDatos.idPersona);
                string nombre = personaDatos.nombres;
                string paterno = personaDatos.paterno;
                string materno = personaDatos.materno;
                string documento = personaDatos.numero_Documento;
                MessageBox.Show("El usuario ya está registrado.\rNombre: " + nombre + ".\rApellido Paterno: " + paterno + ".\rApelllido Materno: " + materno + ".\rDoc. Identidad: " + documento + ".", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cancelar();

            }
        }

        //private void ufl_Leave(object sender, EventArgs e)
        //{
        //    ((TextBox)sender).Text = Utils.Utils.uppercaseFirstLetter(((TextBox)sender).Text);
        //}

        private void soloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyLetters(sender, e);
        }

        private void dgvLista_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = servicio.usuarioBuscar(Util.header, txtParametro.Text.Trim());
            Utils.Wfa.hideHeadersDGV(dgvLista, new List<string>() { "idUsuario", "ci", "idLugarExpedido", 
                "fechaRegistro", "registroActivo", "usuarioRegistro" });
            Utils.Wfa.setHeadersDGV(dgvLista);
        }

        private void listarPersonas()
        {
            dgvListaPersonas.DataSource = servicio.personaListarVista(Util.header);
            Utils.Wfa.hideHeadersDGV(dgvListaPersonas, new List<string>() { "idPersona", "idPais", "imagen", "pin", "idLugarExpedido", "idTipoDocumento", "nombres", "paterno", "materno" });
            Utils.Wfa.setHeadersDGV(dgvListaPersonas);

            dgvListaPersonas.Columns["nombre_Completo"].DisplayIndex = 1;
            dgvListaPersonas.Columns["domicilio"].DisplayIndex = 2;
            dgvListaPersonas.Columns["sexo"].DisplayIndex = 3;
            dgvListaPersonas.Columns["estado_Civil"].DisplayIndex = 4;
            dgvListaPersonas.Columns["tipo_Documento"].DisplayIndex = 5;
            dgvListaPersonas.Columns["numero_Documento"].DisplayIndex = 6;
            dgvListaPersonas.Columns["fecha_Nacimiento"].DisplayIndex = 9;

        }

        private void dgvListaPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {         
            idPersona = Convert.ToInt32(dgvListaPersonas.Rows[dgvListaPersonas.CurrentRow.Index].Cells["idPersona"].Value);
            pnlPersonas.Visible = false;
           
            formarUsuarioPersona_Leave();
            
            bandera = true;
        }

        private void cargarCamposPersona(int idPersona)
        {
            Limpiar();
            SrMidasD.Persona personaDatos = servicio.personaGet(Util.header, idPersona);
            SrMidasD.TipoDocumento tipoDocumento = servicio.tipoDocumentoGet(Util.header, Convert.ToInt32(personaDatos.idTipoDocumento.ToString()));
           
          
            lblNombre.Text = personaDatos.nombres;
            lblPaterno.Text = personaDatos.paterno;
            lblMaterno.Text = personaDatos.materno;

            lblDocumento.Text = tipoDocumento.descripcion + " -" + personaDatos.numero_Documento;

            Util.pintarDatagridwiew(dgvLista, "Gray", "Gray");
        }

       

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {      
            dgvListaPersonas.DataSource = servicio.personaBuscar(Util.header, txtBuscar.Text);
        }

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarCampos();
            bandera = false;
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlLista3);
            Util.pnlListaActivar(true, btnPnlDatos);
            Util.pnlListaActivar(false, btnPnlLista2);
            txtUsuario.Focus();
        }

 

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Util.pnlListaActivar(false, btnPnlLista);
            Util.pnlListaActivar(false, btnPnlDatos);
            Util.pnlListaActivar(true, btnPnlLista2);
            Util.pnlListaActivar(true, btnPnlLista3);
        }

        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyDecimals(sender,e);
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender,e);
            }
        }
    }
}
