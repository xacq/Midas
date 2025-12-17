
using MidasD.Reportes;
using MidasD.SrArgos;
using MidasD.SrMidasD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MidasD.Reportes;


namespace MidasD
{
    public partial class FrmSueldoMensualEscalaSalarial : Form
    {
        SrMidasD.MidasDServiceClient servicio;

        SrMidasD.Usuario usuario;

        public int idFianzaIns, claseInt, nivelsalarialInt, numeroItemInt, sueldoMensualInt,incrementoInt,gestionInt;
        public DateTime f;
        public bool bandera;
    
        FrmCargando frmCargando;
        DataGridViewCellEventArgs ee;
        public double CantidadActual;

        List<Control>  btnPnlDatos, btnPnlLista3;

        public FrmSueldoMensualEscalaSalarial(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
    
            this.usuario = usuario;
          
 
            btnPnlLista3 = new List<Control>() { btnSalir};
         
            btnPnlDatos = new List<Control>() { btnGuardar, btnCancelar,pnlDatos,panFuncionario,panBotones,grProductos,tpgEditarDatos };
            Util.btn_Mouse(new List<PictureBox>() {  btnSalir });

          
            txtBuscar.Focus();
        }

        //Limpiar Campos
        public void limpiarcampos()
        {        
            try
            {
                txtBuscar.Clear();
              

                try
                {
                    dgvListaAux.Rows.Clear();

                }
                catch { }
                try
                {
                    dgvLista.Rows.Clear();

                }
                catch { }
            }
            catch { }
        }

        public void fianzaDescuentoInsertar()
        {
            limpiarErrores();
            try
            {
                foreach (DataGridViewRow dr in dgvLista.Rows)
                {
                    //SrMidasD.Descuento descuento = new SrMidasD.Descuento();

                    //insertarFDN(Convert.ToInt32(dr.Cells["idEscalaSalarial"].Value), descuento, dr);
                } 
            }
            catch
            {
                MessageBox.Show("Ha Sucedido un Error Revise los Datos Ingresados por Favor.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void  fianzaDescuentoEditar()
        {
            //idFianzaIns =Convert.ToInt32(lblidFianza.Text.ToString());


            foreach (DataGridViewRow dr in dgvListaAux.Rows)/*Eliminacion Fisica Descuento*/
            {
                servicio.descuentoEliminarfisicoEditar(Util.header, Convert.ToInt32(dr.Cells["idFianzaAux"].Value));
            }

            int filasDescuento = Convert.ToInt32(dgvLista.Rows.Count) - 1;

            for (int i = 0; i < filasDescuento; i++)
            {
                
                SrMidasD.Descuento descuento = new SrMidasD.Descuento();
                descuento.monto_Beneficiario = Convert.ToDouble(dgvLista.Rows[i].Cells[5].Value);
                descuento.idFianza = idFianzaIns;
                if(Convert.ToDouble(dgvLista.Rows[i].Cells[1].Value) != 0)
                {
                    descuento.t727 = Convert.ToDouble(dgvLista.Rows[i].Cells[1].Value);
                }
                if (Convert.ToInt32(dgvLista.Rows[i].Cells[2].Value) != 0)
                {
                    descuento.c21 = Convert.ToInt32(dgvLista.Rows[i].Cells[2].Value);
                }
                descuento.mes = Convert.ToInt32(dgvLista.Rows[i].Cells[3].Value);
                descuento.anio = Convert.ToInt32(dgvLista.Rows[i].Cells[4].Value);

                if (Convert.ToBoolean(dgvLista.Rows[i].Cells[6].Value) != false)
                {
                    descuento.validado = Convert.ToBoolean(dgvLista.Rows[i].Cells[6].Value);
                }

                if (dgvLista.Rows[i].Cells[7].Value!=null)
                {
                    descuento.validado_Por = Convert.ToString(dgvLista.Rows[i].Cells[7].Value);
                }

                if (dgvLista.Rows[i].Cells[8].Value == null)
                {
                    descuento.observacion = "Mes Descuento Regular Editado";
                }
                else
                {
                    descuento.observacion = Convert.ToString(dgvLista.Rows[i].Cells[8].Value);
                }


                if (dgvLista.Rows[i].Cells[9].Value == null)
                {
                    descuento.usuarioRegistro = usuario.nombre_Usuario;
                }
                else
                {
                    descuento.usuarioRegistro = Convert.ToString(dgvLista.Rows[i].Cells[9].Value);
                }


                if (dgvLista.Rows[i].Cells[10].Value == null)
                {
                    descuento.fechaRegistro = DateTime.Now.Date;
                }
                else
                {
                    descuento.fechaRegistro = Convert.ToDateTime(dgvLista.Rows[i].Cells[10].Value);
                }


                if (Convert.ToBoolean(dgvLista.Rows[i].Cells[11].Value) == false)
                {
                    descuento.registroActivo = true;
                }
                else
                {
                    descuento.registroActivo = Convert.ToBoolean(dgvLista.Rows[i].Cells[11].Value);
                }
                servicio.descuentoInsertar(Util.header, descuento);
            }

           
            MessageBox.Show("La Fianza ha sido Editada.", "::: Midas - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);

            limpiarcampos();

           
        }


        public void insertarFDN(int idFianzaFD, SrMidasD.Descuento descuento, DataGridViewRow dr)//Reutilizamos Insertar Detalle Venta Como para Insertar Un Nuevo Detalle venta en su Editar
        {
 
            descuento.idFianza = idFianzaFD;
            descuento.anio = Convert.ToInt32(dr.Cells["anio"].Value);
            descuento.mes = Convert.ToInt32(dr.Cells["mes"].Value);
            descuento.monto_Beneficiario = Math.Round(Convert.ToDouble(dr.Cells["monto"].Value), 2);

            descuento.usuarioRegistro = usuario.nombre_Usuario;
            descuento.registroActivo = true;
            descuento.fechaRegistro = DateTime.Now.Date;

            servicio.descuentoInsertar(Util.header, descuento);
        }

        //Se cargan campos para Editar y cambiar Datos
        private async Task cargarCamposFianzas()
        {
            frmCargando = new FrmCargando();
            frmCargando.Show();
            await Task.Delay(250);

  
            //Cargamos los Datos Dinamicos a una Grilla Auxiliar para luego Añadirlos Uno a Uno al la Grilla de Trabajo
            dgvListaAux.DataSource = servicio.paEscalaSalarialGestion(Util.header, Convert.ToInt32(txtBuscar.Text.ToString()));
            foreach (DataGridViewRow dr in dgvListaAux.Rows)
            {
              

                string idEscalaSalarialtring = dr.Cells["idEscalaSalarialAux"].Value.ToString();
                string idSueldoMensualString = dr.Cells["idSueldoMensualAux"].Value.ToString();
                string categoriaString = dr.Cells["categoriaAux"].Value.ToString();
                string descripcionPuestoString = dr.Cells["denominacion_PuestoAux"].Value.ToString();

                if (dr.Cells["claseAux"].Value != null)
                {
                    claseInt = Convert.ToInt32(dr.Cells["claseAux"].Value);
                }
               
                if(dr.Cells["nivel_SalarialAux"].Value!=null)
                {
                    nivelsalarialInt = Convert.ToInt32(dr.Cells["nivel_SalarialAux"].Value);
                }

                if (dr.Cells["numero_ItemsAux"].Value != null)
                {
                    numeroItemInt = Convert.ToInt32(dr.Cells["numero_ItemsAux"].Value);
                }

                if (dr.Cells["sueldo_MensualAux"].Value != null)
                {
                    sueldoMensualInt = Convert.ToInt32(dr.Cells["sueldo_MensualAux"].Value);
                }

                if (dr.Cells["incrementoAux"].Value != null)
                {
                    incrementoInt = Convert.ToInt32(dr.Cells["incrementoAux"].Value);
                }

                if (dr.Cells["gestionAux"].Value != null)
                {
                    gestionInt = Convert.ToInt32(dr.Cells["gestionAux"].Value);
                }


                //string usuarioRegistro = (dr.Cells["usuarioRegistroAux"].Value).ToString();
                //DateTime fechaRegistro = Convert.ToDateTime((dr.Cells["fechaRegistroAux"].Value).ToString());
                //bool registroActivo= Convert.ToBoolean(dr.Cells["registroActivoAux"].Value.ToString());

               

                dgvLista.Rows.Add(idEscalaSalarialtring,idSueldoMensualString,categoriaString,claseInt,nivelsalarialInt, descripcionPuestoString, numeroItemInt,sueldoMensualInt,incrementoInt,gestionInt,usuarioRegistro,fechaRegistro,registroActivo);


                dgvLista.Rows[dgvLista.Rows.Count - 1].Cells["sueldo_Mensual"].Selected = true;
               
            }
           

           



            frmCargando.Close();
        }

     

        //Limpiar Errores
        public void limpiarErrores()
        {
            erpError.Clear();
        }

      

        //Boton Cancelar
        private  void btnCancelar_Click(object sender, EventArgs e)
        {
             cancelar();
        }

        

        //validar el campo descontar
        private int validarSueldoDgv()
        {
            foreach (DataGridViewRow dr in dgvLista.Rows)
                if (Convert.ToDouble(dr.Cells["sueldo_mensual"].Value) <= 0)
                    return dr.Index;
            return -1;
        }

        private void dgvLista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                /*Solo Refrescamos la Columnna Evitando que se Realize todo El Calculo Innesesario*/
                if (e.ColumnIndex == 2)
                {
                    CantidadActual = Math.Round(Convert.ToDouble(dgvLista.Rows[e.RowIndex].Cells["sueldo_mensual"].Value), 2);
                    /*Sacamos la cantidad Actual que se edita que no sea menor a 0*/
                    
                    if (CantidadActual <= 0)
                    {
                        MessageBox.Show("El Sueldo Mensual no debe ser menor a\n" + ": " + 0, "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else//Si es cero se coloca de nuevo el valor de descuento por mes
                    {
                        dgvLista.Rows[e.RowIndex].Cells["sueldo_mensual"].Value = CantidadActual;
                    }

                }
                else
                {/*Calculamos Todos Los Demas Valores*/

                    
                }
            }
            catch (Exception) { }
        }

       

        private  void btnGuardar_Click(object sender, EventArgs e)
        {
            fianzaDescuentoEditar();
            limpiarErrores();
            limpiarcampos();

           
        }

        
        private void dgvLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dgvLista.CurrentCell.ColumnIndex;
            if (column == 2)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    Util.notPaste = false;
                    txt.KeyPress += Utils.Wfa.onlyDecimals;
                    txt.MouseDown += Utils.Wfa.notButtonRight;
                }
            }
           
        }


       

        //Datos para validar el formulario
        private async void frmEntrada_Load(object sender, EventArgs e)
        {
            txtBuscar.Text = servicio.fechaServidor().Year.ToString();
            await editarCampos();
            dgvLista.RowPostPaint += Utils.Wfa.rowPostPaintDGV;
            
        }

       

       

      

     

        public async Task editarCampos()
        {
            limpiarErrores();
            await cargarCamposFianzas();

            bandera = false;

            this.tabControl.SelectedTab = tpgEditarDatos;


            if (dgvLista.RowCount >= 1)
            {
                int fila = dgvLista.RowCount;
            }
            else
            {
                dgvLista.AllowUserToAddRows = true;
                MessageBox.Show("No existen Descuento Inserte Filas y Registre", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void dgvListaFianzas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            await editarCampos();
        }

      

        private void  cancelar()
        {
            limpiarErrores();
            limpiarcampos();


            try
            {
                dgvListaAux.Rows.Clear();

            }
            catch { }
            try
            {
                dgvLista.Rows.Clear();

            }
            catch { }

            txtBuscar.Text = servicio.fechaServidor().Year.ToString();


        }


        //Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

      
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                this.ee = e;
            }
            catch { }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvListaAux.Rows.Clear();

            }
            catch { }
            try
            {
                dgvLista.Rows.Clear();

            }
            catch { }
            await editarCampos();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar_Click(sender, e);
            }
        }

        //Opcion eliminar Fila
        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount >= 1)
            {
                int fila = dgvLista.CurrentRow.Index;
                if (fila != dgvLista.RowCount)
                {
                    DialogResult ResultadoDialogo = MessageBox.Show("Se va a eliminar el Descuento seleccionado.\r¿Desea continuar?.", "::: MidasD - Consulta :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ResultadoDialogo == DialogResult.Yes)
                    {
                        dgvLista.Rows.RemoveAt(fila);
                        MessageBox.Show("Descuento Salida eliminada.", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Entrada Salida", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No existen Descuento para eliminar", "::: MidasD - Información :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count >1)
            {
                dgvLista.AllowUserToAddRows = true;
                int fila = dgvLista.CurrentRow.Index;
                if (fila != dgvLista.Rows.Count)
                {
                    try
                    {
                        dgvLista.Rows.Insert(dgvLista.Rows.Count);
                    }
                    catch { }
                   
                }
            }
            else
            {
                dgvLista.AllowUserToAddRows = true;
            }

        }

    }
}
