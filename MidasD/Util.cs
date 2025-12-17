using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidasD
{
    public class Util
    {
        public static SrMidasD.Header header { get; set; }
        public static SrMidasD.Usuario usuario { get; set; }

        public static string path { get; set; }
        public static string sistema { get; set; }
        public static string version { get; set; }
        public static string archivoExe { get; set; }

        public static void btn_Mouse(List<PictureBox> buttons) 
        {
            foreach (PictureBox button in buttons)
            {
                string eso=button.Name;
                button.MouseHover += btn_MouseHover;
                button.MouseLeave += btn_MouseLeave;
            }
        }

        public static void AutoCompleteCombo(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e, bool blnLimitToList)
        {
            string strFindStr = "";

            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }

            int intIdx = -1;

            // Search the string in the ComboBox list.

            intIdx = cb.FindString(strFindStr);

            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
            {
                e.Handled = blnLimitToList;
            }
        }
     

        public static bool notPaste;

        public static void pintarDatagridwiew(DataGridView datagridwiew, string foreColor, string backGroundColor)
        {
            datagridwiew.ForeColor = Color.FromName(foreColor);
            datagridwiew.BackgroundColor = Color.FromName(backGroundColor);
        }

        public static void errorMensaje(ErrorProvider errorNombre, Control control, string mensaje)
        {
            errorNombre.SetError(control,mensaje);
        }

        public static void pintarDatagridwiewIndex(DataGridView datagridwiew,int index, string foreColor, string backGroundColor)
        {
            datagridwiew.Rows[index].DefaultCellStyle.ForeColor= Color.FromName(foreColor);
            datagridwiew.Rows[index].DefaultCellStyle.BackColor = Color.FromName(backGroundColor);
        }

    
        public static void pnlListaActivar(bool activar, List<Control> controls)
        {
            foreach (Control control in controls)
            {
                if (control is PictureBox)
                {
                    PictureBox button = (PictureBox)control;
                    if (!activar)
                    {
                        switch (button.Name)
                        {
                            case "btnSeleccionar": button.Image = Properties.Resources.select_inactive; break;
                            case "btnContinuar": button.Image = Properties.Resources.next_inactive; break;
                            case "btnBuscar": button.Image = Properties.Resources.search_inactive; break;
                            case "btnBuscarPersonas": button.Image = Properties.Resources.search_inactive; break;
                            case "btnBuscarEquipo": button.Image = Properties.Resources.search_inactive; break;                         
                            case "btnSalir": button.Image = Properties.Resources.exit_inactive; break;
                            case "btnImprimir": button.Image = Properties.Resources.print_inactive; break;
                            case "btnImprimir1": button.Image = Properties.Resources.print_inactive; break;
                            case "btnImprimir2": button.Image = Properties.Resources.print_inactive; break;
                            case "btnImprimir3": button.Image = Properties.Resources.print_inactive; break;
                            case "btnConsultar": button.Image = Properties.Resources.consult_inactive; break;
                            case "btnNuevo": button.Image = Properties.Resources.new_inactive; break;
                            case "btnNuevoIngreso": button.Image = Properties.Resources.save_inactive; break;
                            case "btnNuevoLibro": button.Image = Properties.Resources.new_inactive; break;
                            case "btnNuevoRegistroPersona": button.Image = Properties.Resources.new_inactive; break;
                            case "btnNuevoEquipo": button.Image = Properties.Resources.new_inactive; break;
                            case "btnNuevoColportor": button.Image = Properties.Resources.new_inactive; break;
                            case "btnEditar": button.Image = Properties.Resources.edit_inactive; break;
                            case "btnEditarEquipo": button.Image = Properties.Resources.edit_inactive; break;
                            case "btnBaja": button.Image = Properties.Resources.delet_inactive; break;
                            case "btnQuitar": button.Image = Properties.Resources.delet_inactive; break;
                            case "btnBajaEquipo": button.Image = Properties.Resources.delet_inactive; break;
                            case "btnRestablecerClave": button.Image = Properties.Resources.reset_password_inactive; break;
                            case "btnGuardar": button.Image = Properties.Resources.save_inactive; break;
                            case "btnGuardarEquipo": button.Image = Properties.Resources.save_inactive; break;
                            case "btnCancelar": button.Image = Properties.Resources.cancel_inactive; break;
                            case "btnCancelarEquipo": button.Image = Properties.Resources.cancel_inactive; break;
                            case "btnAcceder": button.Image = Properties.Resources.loginb_inactive; break;
                            case "btnAsignar": button.Image = Properties.Resources.assign_inactive; break;
                            case "btnValidar": button.Image = Properties.Resources.validar_inactive; break;
                            case "btnQuitarSeleccion": button.Image = Properties.Resources.deselect_inactive; break;
                        }
                    }
                    else
                    {
                        switch (button.Name)
                        {
                            case "btnSeleccionar": button.Image = Properties.Resources.select; break;
                            case "btnContinuar": button.Image = Properties.Resources.next; break;
                            case "btnBuscar": button.Image = Properties.Resources.search; break;
                            case "btnBuscarPersonas": button.Image = Properties.Resources.search; break;
                            case "btnBuscarEquipo": button.Image = Properties.Resources.search; break;
                            case "btnBuscarColportor": button.Image = Properties.Resources.search; break;
                            case "btnSalir": button.Image = Properties.Resources.exit_; break;
                            case "btnSalirColportor": button.Image = Properties.Resources.exit_; break;
                            case "btnImprimir": button.Image = Properties.Resources.print; break;
                            case "btnImprimir1": button.Image = Properties.Resources.print; break;
                            case "btnImprimir2": button.Image = Properties.Resources.print; break;
                            case "btnImprimir3": button.Image = Properties.Resources.print; break;
                            case "btnConsultar": button.Image = Properties.Resources.consult; break;
                            case "btnNuevo": button.Image = Properties.Resources._new; break;
                            case "btnNuevoIngreso": button.Image = Properties.Resources.save; break;
                            case "btnNuevoLibro": button.Image = Properties.Resources._new; break;
                            case "btnNuevoRegistroPersona": button.Image = Properties.Resources._new; break;
                            case "btnNuevoEquipo": button.Image = Properties.Resources._new; break;
                            case "btnNuevoColportor": button.Image = Properties.Resources._new; break;
                            case "btnEditar": button.Image = Properties.Resources.edti; break;
                            case "btnEditarEquipo": button.Image = Properties.Resources.edti; break;
                            case "btnEditarColportor": button.Image = Properties.Resources.edti; break;
                            case "btnBaja": button.Image = Properties.Resources.delete; break;
                            case "btnQuitar": button.Image = Properties.Resources.delete; break;
                            case "btnBajaEquipo": button.Image = Properties.Resources.delete; break;
                            case "btnBajaColportor": button.Image = Properties.Resources.delete; break;
                            case "btnRestablecerClave": button.Image = Properties.Resources.reset_password; break;
                            case "btnGuardar": button.Image = Properties.Resources.save; break;
                            case "btnGuardarEquipo": button.Image = Properties.Resources.save; break;
                            case "btnGuardarColportor": button.Image = Properties.Resources.save; break;
                            case "btnCancelar": button.Image = Properties.Resources.cancel; break;
                            case "btnCancelarEquipo": button.Image = Properties.Resources.cancel; break;
                            case "btnCancelarColportor": button.Image = Properties.Resources.cancel; break;
                            case "btnAcceder": button.Image = Properties.Resources.loginb; break;
                            case "btnAsignar": button.Image = Properties.Resources.assign; break;
                            case "btnValidar": button.Image = Properties.Resources.validar; break;
                            case "btnQuitarSeleccion": button.Image = Properties.Resources.deselect; break;
                        }
                    }
                }
                control.Enabled = activar;
            }
        }

        public static void btn_MouseHover(object sender, EventArgs e)
        {
            PictureBox button = ((PictureBox)sender);
            switch (button.Name)
            {
                case "btnSeleccionar": button.Image = Properties.Resources.select_hover; break;
                case "btnContinuar": button.Image = Properties.Resources.next_hover; break;
                case "btnBuscar": button.Image = Properties.Resources.search_hover; break;
                case "btnBuscarPersonas": button.Image = Properties.Resources.search_hover; break;
                case "btnBuscarEquipo": button.Image = Properties.Resources.search_hover; break;
                case "btnBuscarColportor": button.Image = Properties.Resources.search_hover; break;
                case "btnSalir": button.Image = Properties.Resources.exit_hover; break;
                case "btnSalirColportor": button.Image = Properties.Resources.exit_hover; break;
                case "btnImprimir": button.Image = Properties.Resources.print_hover; break;
                case "btnImprimir1": button.Image = Properties.Resources.print_hover; break;
                case "btnImprimir2": button.Image = Properties.Resources.print_hover; break;
                case "btnImprimir3": button.Image = Properties.Resources.print_hover; break;
                case "btnConsultar": button.Image = Properties.Resources.consult_hover; break;
                case "btnNuevo": button.Image = Properties.Resources.new_hover; break;
                case "btnNuevoIngreso": button.Image = Properties.Resources.save_hover; break;
                case "btnNuevoLibro": button.Image = Properties.Resources.new_hover; break;
                case "btnNuevoRegistroPersona": button.Image = Properties.Resources.new_hover; break;
                case "btnNuevoEquipo": button.Image = Properties.Resources.new_hover; break;
                case "btnNuevoColportor": button.Image = Properties.Resources.new_hover; break;
                case "btnEditar": button.Image = Properties.Resources.edit_hover; break;
                case "btnEditarEquipo": button.Image = Properties.Resources.edit_hover; break;
                case "btnEditarColportor": button.Image = Properties.Resources.edit_hover; break;
                case "btnBaja": button.Image = Properties.Resources.delete_hover; break;
                case "btnQuitar": button.Image = Properties.Resources.delete_hover; break;
                case "btnBajaEquipo": button.Image = Properties.Resources.delete_hover; break;
                case "btnBajaColportor": button.Image = Properties.Resources.delete_hover; break;
                case "btnRestablecerClave": button.Image = Properties.Resources.reset_password_hover; break;
                case "btnGuardar": button.Image = Properties.Resources.save_hover; break;
                case "btnGuardarEquipo": button.Image = Properties.Resources.save_hover; break;
                case "btnGuardarColportor": button.Image = Properties.Resources.save_hover; break;
                case "btnCancelar": button.Image = Properties.Resources.cancel_hover; break;
                case "btnCancelarEquipo": button.Image = Properties.Resources.cancel_hover; break;
                case "btnCancelarColportor": button.Image = Properties.Resources.cancel_hover; break;
                case "btnAcceder": button.Image = Properties.Resources.login_hover; break;
                case "btnAsignar": button.Image = Properties.Resources.assign_hover; break;
                case "btnValidar": button.Image = Properties.Resources.validar_hover; break;
                case "btnQuitarSeleccion": button.Image = Properties.Resources.deselect_hover; break;
            }
        }

        public static void btn_MouseLeave(object sender, EventArgs e)
        {
            PictureBox button = ((PictureBox)sender);
            switch (button.Name)
            {
                case "btnSeleccionar": if (button.Enabled) ((PictureBox)sender).Image = Properties.Resources.select;
                    else ((PictureBox)sender).Image = Properties.Resources.select_inactive; break;

                case "btnContinuar": if (button.Enabled) ((PictureBox)sender).Image = Properties.Resources.next;
                    else ((PictureBox)sender).Image = Properties.Resources.next_inactive; break;

                case "btnBuscar": if (button.Enabled) button.Image = Properties.Resources.search;
                    else button.Image = Properties.Resources.search_inactive; break;

                case "btnBuscarPersonas": if (button.Enabled) button.Image = Properties.Resources.search;
                    else button.Image = Properties.Resources.search_inactive; break;

                case "btnBuscarEquipo": if (button.Enabled) button.Image = Properties.Resources.search;
                    else button.Image = Properties.Resources.search_inactive; break;

                case "btnBuscarColportor": if (button.Enabled) button.Image = Properties.Resources.search;
                    else button.Image = Properties.Resources.search_inactive; break;

                case "btnSalir": if (button.Enabled) button.Image = Properties.Resources.exit_;
                    else button.Image = Properties.Resources.exit_inactive; break;

                case "btnSalirColportor": if (button.Enabled) button.Image = Properties.Resources.exit_;
                    else button.Image = Properties.Resources.exit_inactive; break;

                case "btnImprimir": if (button.Enabled) button.Image = Properties.Resources.print;
                    else button.Image = Properties.Resources.print_inactive; break;

                case "btnImprimir1":
                    if (button.Enabled) button.Image = Properties.Resources.print;
                    else button.Image = Properties.Resources.print_inactive; break;

                case "btnImprimir2":
                    if (button.Enabled) button.Image = Properties.Resources.print;
                    else button.Image = Properties.Resources.print_inactive; break;

                case "btnImprimir3":
                    if (button.Enabled) button.Image = Properties.Resources.print;
                    else button.Image = Properties.Resources.print_inactive; break;

                case "btnConsultar": if (button.Enabled) button.Image = Properties.Resources.consult;
                    else button.Image = Properties.Resources.consult_inactive; break;

                case "btnNuevo": if (button.Enabled) button.Image = Properties.Resources._new;
                    else button.Image = Properties.Resources.new_inactive; break;

                 case "btnNuevoIngreso": if (button.Enabled) button.Image = Properties.Resources.save;
                    else button.Image = Properties.Resources.save_inactive; break;

                case "btnNuevoLibro": if (button.Enabled) button.Image = Properties.Resources._new;
                    else button.Image = Properties.Resources.new_inactive; break;

                case "btnNuevoRegistroPersona": if (button.Enabled) button.Image = Properties.Resources._new;
                    else button.Image = Properties.Resources.new_inactive; break;

                case "btnNuevoEquipo": if (button.Enabled) button.Image = Properties.Resources._new;
                    else button.Image = Properties.Resources.new_inactive; break;

                case "btnNuevoColportor": if (button.Enabled) button.Image = Properties.Resources._new;
                    else button.Image = Properties.Resources.new_inactive; break;

                case "btnEditar": if (button.Enabled) button.Image = Properties.Resources.edti;
                    else button.Image = Properties.Resources.edit_inactive; break;

                case "btnEditarEquipo": if (button.Enabled) button.Image = Properties.Resources.edti;
                    else button.Image = Properties.Resources.edit_inactive; break;

                case "btnEditarColportor": if (button.Enabled) button.Image = Properties.Resources.edti;
                    else button.Image = Properties.Resources.edit_inactive; break;

                case "btnBaja": if (button.Enabled) button.Image = Properties.Resources.delete;
                    else button.Image = Properties.Resources.delet_inactive; break;

                case "btnQuitar": if (button.Enabled) button.Image = Properties.Resources.delete;
                    else button.Image = Properties.Resources.delet_inactive; break;

                case "btnBajaEquipo": if (button.Enabled) button.Image = Properties.Resources.delete;
                    else button.Image = Properties.Resources.delet_inactive; break;

                case "btnBajaColportor": if (button.Enabled) button.Image = Properties.Resources.delete;
                    else button.Image = Properties.Resources.delet_inactive; break;

                case "btnRestablecerClave": if (button.Enabled) button.Image = Properties.Resources.reset_password;
                    else button.Image = Properties.Resources.reset_password_inactive; break;

                case "btnGuardar": if (button.Enabled) button.Image = Properties.Resources.save;
                    else button.Image = Properties.Resources.save_inactive; break;

                case "btnGuardarEquipo": if (button.Enabled) button.Image = Properties.Resources.save;
                    else button.Image = Properties.Resources.save_inactive; break;

                case "btnGuardarColportor": if (button.Enabled) button.Image = Properties.Resources.save;
                    else button.Image = Properties.Resources.save_inactive; break;

                case "btnCancelar": if (button.Enabled) button.Image = Properties.Resources.cancel;
                    else button.Image = Properties.Resources.cancel_inactive; break;

                case "btnCancelarEquipo": if (button.Enabled) button.Image = Properties.Resources.cancel;
                    else button.Image = Properties.Resources.cancel_inactive; break;

                case "btnCancelarColportor": if (button.Enabled) button.Image = Properties.Resources.cancel;
                    else button.Image = Properties.Resources.cancel_inactive; break;

                case "btnAcceder": if (button.Enabled) button.Image = Properties.Resources.login;
                    else button.Image = Properties.Resources.loginb_inactive; break;

                case "btnAsignar": if (button.Enabled) button.Image = Properties.Resources.assign;
                    else button.Image = Properties.Resources.assign_inactive; break;

                case "btnValidar":
                    if (button.Enabled) button.Image = Properties.Resources.validar;
                    else button.Image = Properties.Resources.validar_inactive; break;

                case "btnQuitarSeleccion":
                    if (button.Enabled) button.Image = Properties.Resources.deselect;
                    else button.Image = Properties.Resources.deselect_inactive; break;


            }
        }

        

    }



}
