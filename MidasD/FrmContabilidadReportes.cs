
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
    public partial class FrmContabilidadReportes : Form
    {
        SrMidasD.MidasDServiceClient servicio;
        SrMidasD.Usuario usuario;
  
        public int idFianzaIns, idUnidadEjecutoraIns,idTipoFianzaIns,mesIns,anioIns;
        public DateTime f;
        public bool bandera;


        public bool c21 = false;
        DateTime fecha1,fecha2, fechaActualServidor;


        List<Control>  btnPnlLista3;

        public FrmContabilidadReportes(SrMidasD.Usuario usuario)
        {
            InitializeComponent();
            servicio = new SrMidasD.MidasDServiceClient();
    
            this.usuario = usuario;
            fechaActualServidor = servicio.fechaServidor();
            fecha1 = new DateTime(fechaActualServidor.Year, fechaActualServidor.Month, 01);
            fecha2 = new DateTime(fechaActualServidor.Year, fechaActualServidor.Month, fechaActualServidor.Day);
            mtfecha1.Text = fecha1.ToString("dd-MM-yyyy");
            mtfecha2.Text = fecha2.ToString("dd-MM-yyyy");
            btnPnlLista3 = new List<Control>() { btnSalir};

            Util.btn_Mouse(new List<PictureBox>() { btnSalir,btnImprimir });


            cargarUnidadEjecutora();

            List<Item> listaAnio = new List<Item>();

            for (int i = 0; i < 4; i++)
            {
                listaAnio.Add(new Item((DateTime.Now.Year-i).ToString(), i));
            }
  
            cbxAnio.DisplayMember = "Name";
            cbxAnio.ValueMember = "Value";
            cbxAnio.DataSource = listaAnio;

            cbxAnio.SelectedValue = 0;



        }

        class ClassItems
        {
            public string Name;
            public int Value;

            public ClassItems(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }

        //Listar las Unidades Encargadas
        private void cargarUnidadEjecutora()
        {

            List<Item> lista = new List<Item>();

            lista.Add(new Item("Enero", 1));
            lista.Add(new Item("Febrero", 2));
            lista.Add(new Item("Marzo", 3));
            lista.Add(new Item("Abril", 4));
            lista.Add(new Item("Mayo", 5));
            lista.Add(new Item("Junio", 6));
            lista.Add(new Item("Julio", 7));
            lista.Add(new Item("Agosto", 8));
            lista.Add(new Item("Septiembre", 9));
            lista.Add(new Item("Octubre", 10));
            lista.Add(new Item("Noviembre", 11));
            lista.Add(new Item("Diciembre", 12));

            cbxMes.DisplayMember = "Name";
            cbxMes.ValueMember = "Value";
            cbxMes.DataSource = lista;

            int mesActual = DateTime.Now.Month;

            cbxMes.SelectedValue = mesActual;
        }

        //Redimencionar un Combo Box
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

       

        //Reiniciar Verificacion
        public void reiniciarVerificacion()
        {
            c21 = false;
        }


        public void imprimir()
        {

            if (rbt727.Checked==true)
            {
                new FrmCrCuentaContable(0, 0, Convert.ToInt32(cbxMes.SelectedValue.ToString()), Convert.ToInt32(cbxAnio.SelectedItem.ToString()),usuario.nombre_Usuario).ShowDialog();
            }
            if (rbEcoGlobales.Checked == true)
            {
                new FrmCrCuentaContable(2, 3, Convert.ToInt32(cbxMes.SelectedValue.ToString()), Convert.ToInt32(cbxAnio.SelectedItem.ToString()), usuario.nombre_Usuario).ShowDialog();
            }
            //if (rbEcoDescuento.Checked == true)
            //{
            //    new FrmCrCuentaContable(2, 2, Convert.ToInt32(cbxMes.SelectedValue.ToString()), Convert.ToInt32(txtAnioBuscar.Text), usuario.nombre_Usuario).ShowDialog();
            //}
            //if (rbEcoTotales.Checked == true)
            //{
            //    new FrmCrCuentaContable(3, 3, Convert.ToInt32(cbxMes.SelectedValue.ToString()), Convert.ToInt32(txtAnioBuscar.Text), usuario.nombre_Usuario).ShowDialog();
            //}
            if (rbBienesGravamenes.Checked == true)
            {
                new FrmCrCuentaContable(1, 1, Convert.ToInt32(cbxMes.SelectedValue.ToString()), Convert.ToInt32(cbxAnio.SelectedItem.ToString()), usuario.nombre_Usuario).ShowDialog();
            }


        }



        //Limpiar Errores
        public void limpiarErrores()
        {
            erpError.Clear();
        }

        //Listar Fianzas Registradas Por Unidad Ejecutora
        

        //Boton Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarErrores();

        }

        //Datos para validar el formulario
        private void frmEntrada_Load(object sender, EventArgs e)
        {
          
            //txtAnioBuscar.KeyPress += Utils.Wfa.onlyNumbers;
           
            //txtAnioBuscar.Text = DateTime.Now.Year.ToString();
        }

        public class Item
        {
            public string Name { get; set; }
            public int Value { get; set; }

            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }


        //Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        void dgvCombo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here)  
        }

        private void btReclasificaciones_Click(object sender, EventArgs e)
        {
           
             new FrmCrRecaTransDevo("Reclasificaciones", usuario.nombre_Usuario,Convert.ToDateTime(mtfecha1.Text).Date,Convert.ToDateTime(mtfecha2.Text).Date).ShowDialog();

        }

        private void btTransferencias_Click(object sender, EventArgs e)
        {

            new FrmCrRecaTransDevo("Transferencias", usuario.nombre_Usuario, Convert.ToDateTime(mtfecha1.Text).Date, Convert.ToDateTime(mtfecha2.Text).Date).ShowDialog();
        }

        private void btDevoluciones_Click(object sender, EventArgs e)
        {
            new FrmCrRecaTransDevo("Devoluciones", usuario.nombre_Usuario, Convert.ToDateTime(mtfecha1.Text).Date, Convert.ToDateTime(mtfecha2.Text).Date).ShowDialog();
        }

        

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
                imprimir();
        }

        private void btnCartilla_Click(object sender, EventArgs e)
        {
            new FrmImpresionCartillas(usuario).ShowDialog();
        }

       


        //Opcion Solo Numeros
        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.Wfa.onlyNumbers(sender, e);
        }

        //Limpiar al hacer Click
        private void txtAnio_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Clear();
        }

 

        //Opcion Imprimir
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }



        //Insertamos numeracion
        private void dgvGrilla_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Utils.Wfa.rowPostPaintDGV(sender, e);
        }

    }

   
}
