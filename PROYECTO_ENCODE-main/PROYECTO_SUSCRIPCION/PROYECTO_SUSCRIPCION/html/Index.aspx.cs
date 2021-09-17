using BLL;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROYECTO_SUSCRIPCION
{
    public partial class Index : System.Web.UI.Page
    {
        SuscriptorBLL suscriptorBLL = new SuscriptorBLL();
        SuscripcionBLL suscripcionBLL = new SuscripcionBLL();
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEstado.Enabled = false;
            if (!IsPostBack)
            {
                deshabilitarCampos();
                btnNuevo.Enabled = false;
                btnModificar.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar2.Enabled = false;
                btnRegistrarSuscripcion.Enabled = false;
                
            }
        }

        public void buscarSuscriptor(string tipoD, string nroDoc)
        {
            Suscriptor s1 = suscriptorBLL.buscarSuscriptor(tipoD, nroDoc);
            if (s1 == null)
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjNoSeEncontroSuscriptor();", true);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "funcionModal();", true);
                btnNuevo.Enabled = true;
                deshabilitarCampos();
                btnModificar.Enabled = false;
                limpiarCampos();
                return;

            }else if (tipoD == s1.TipoDocumento && nroDoc == s1.NumeroDocumento)
            {
                List<Suscripcion> lst = suscripcionBLL.lstSuscripcion();
                var susc = lst.Where(x => x.IdSuscriptor == s1.IdSuscriptor).FirstOrDefault();
                
                if (susc != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjTieneSuscripcion();", true);
                    id = s1.IdSuscriptor;
                    ViewState["idSuscriptor"] = id;
                    txtNombre.Text = s1.NombreSuscriptor;
                    txtApellido.Text = s1.ApellidoSuscriptor;
                    txtDireccion.Text = s1.Direccion;
                    txtEmail.Text = s1.Email;
                    txtTelefono.Text = s1.NroTelefono;
                    txtNombreUsuario.Text = s1.NombreUsuario;
                    txtContrasena.Text = s1.Contrasena;

                    txtEstado.Text = "Suscripto";

                    btnModificar.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnRegistrarSuscripcion.Enabled = false;
                    btnGuardar.Enabled = false;
                }
                else { 
                    id = s1.IdSuscriptor;
                    ViewState["idSuscriptor"] = id;
                    txtNombre.Text = s1.NombreSuscriptor;
                    txtApellido.Text = s1.ApellidoSuscriptor;
                    txtDireccion.Text = s1.Direccion;
                    txtEmail.Text = s1.Email;
                    txtTelefono.Text = s1.NroTelefono;
                    txtNombreUsuario.Text = s1.NombreUsuario;
                    txtContrasena.Text = s1.Contrasena;
                    
                    txtEstado.Text = "No Suscripto";

                    btnModificar.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnRegistrarSuscripcion.Enabled = true;
                    btnGuardar.Enabled = false;
                }
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarSuscriptor(cboTipoDoc.SelectedValue, txtNroDocumento.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            ViewState["Nuevo"] = true;
            habilitarCampos();
            btnGuardar.Enabled = true;
            btnRegistrarSuscripcion.Enabled = false;
            btnCancelar2.Enabled = true;
            btnModificar.Enabled = false;
            txtNombre.Focus();
            cboTipoDoc.Enabled = false;
            txtNroDocumento.Enabled = false;
            btnNuevo.Enabled = false;
        }
        public bool modificarSuscriptor(string nombre, string apellido, string direccion, string tel, string email, string contrasena, string nroDoc)
        {
            if (cboTipoDoc.SelectedIndex.Equals(0) || string.IsNullOrEmpty(txtNroDocumento.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(txtNombreUsuario.Text) || string.IsNullOrEmpty(txtContrasena.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjDebeIngresarTodosLosDatos();", true);
                return false;
            }
            else
            {
                SuscriptorBLL susBLL = new SuscriptorBLL();
                Suscriptor sus1 = new Suscriptor();
                sus1.NombreSuscriptor = nombre;
                sus1.ApellidoSuscriptor = apellido;
                sus1.Direccion = direccion;
                sus1.NroTelefono = tel;
                sus1.Email = email;
                sus1.Contrasena = contrasena;
                sus1.NumeroDocumento = nroDoc;
                return susBLL.modificarSuscriptor(sus1);
            }
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ViewState["Nuevo"] = false;
            habilitarCampos();
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnBuscar.Enabled = false;
            btnCancelar2.Enabled = true;
            btnRegistrarSuscripcion.Enabled = false;
            btnModificar.Enabled = false;
            cboTipoDoc.Enabled = false;
            txtNroDocumento.Enabled = false;
            txtNombreUsuario.Enabled = false;
        }
        public bool insertarSuscriptor(string nombre, string apellido, string nroDoc, string tipoDoc, string direccion, string tel, string email, string nomUsuario, string contra)
        {
            SuscriptorBLL suscriptorBLL = new SuscriptorBLL();
            Suscriptor suscriptor = new Suscriptor();
            suscriptor.NombreSuscriptor = nombre;
            suscriptor.ApellidoSuscriptor = apellido;
            suscriptor.NumeroDocumento = nroDoc;
            suscriptor.TipoDocumento = tipoDoc;
            suscriptor.Direccion = direccion;
            suscriptor.NroTelefono = tel;
            suscriptor.Email = email;
            suscriptor.NombreUsuario = nomUsuario;
            suscriptor.Contrasena = contra;
            return suscriptorBLL.insertarSuscriptor(suscriptor);
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (bool.Parse(ViewState["Nuevo"].ToString()))
            {
                if (suscriptorBLL.ValidarNombreUsuario(txtNombreUsuario.Text)>0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjNombreUsuarioExiste();", true);
                    btnNuevo.Enabled = false;
                    txtNombreUsuario.Focus();
                }
                else { 
                insertarSuscriptor(txtNombre.Text, txtApellido.Text, txtNroDocumento.Text, cboTipoDoc.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtNombreUsuario.Text, txtContrasena.Text);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjSucriptorRegistrado();", true);
                btnGuardar.Enabled = false;
                btnRegistrarSuscripcion.Enabled = true;
                btnCancelar2.Enabled = false;
                cboTipoDoc.Enabled = true;
                txtNroDocumento.Enabled = true;
                deshabilitarCampos();
                ValidarCampos();
                return;
                }
            }
            else if(!modificarSuscriptor(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtContrasena.Text, txtNroDocumento.Text))
            {
                habilitarCampos();
                //ValidarCampos();
            }else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjSuscriptorModificado();", true);
                btnBuscar.Enabled = true;
                btnRegistrarSuscripcion.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar2.Enabled = true;
                btnModificar.Enabled = false;
                deshabilitarCampos();
                cboTipoDoc.Enabled = true;
                txtNroDocumento.Enabled = true;
                return;
            }
        }
        public bool insertarSuscripcion()
        {
            Suscriptor suscriptor = suscriptorBLL.buscarSuscriptor(cboTipoDoc.SelectedValue, txtNroDocumento.Text);
            Suscripcion suscripcion = new Suscripcion();
            SuscripcionBLL suscripcionBLL = new SuscripcionBLL();
            suscripcion.IdSuscriptor = suscriptor.IdSuscriptor;
            return suscripcionBLL.insertarSuscripcion(suscripcion);
        }
        protected void btnRegistrarSuscripcion_Click(object sender, EventArgs e)
        {
            insertarSuscripcion();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjSuscripcionRegistrada();", true);
            btnRegistrarSuscripcion.Enabled = false;
            limpiarCampos();
            cboTipoDoc.SelectedIndex = 0;
            txtNroDocumento.Text = "";
            return;
        }
        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtNombreUsuario.Text = "";
            txtContrasena.Text = "";
            cboTipoDoc.Focus();

        }
        private void deshabilitarCampos()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDireccion.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;
            txtNombreUsuario.Enabled = false;
            txtContrasena.Enabled = false;
        }

        private void habilitarCampos()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDireccion.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtContrasena.Enabled = true;
        }
        public string validarCamposVacios()
        {

            string faltanDatos = "";
            if (cboTipoDoc.SelectedItem.Equals(0))
            {
                faltanDatos += "Seleccionar tipo doc\n";
                cboTipoDoc.Focus();
            }
            if (string.IsNullOrEmpty(txtNroDocumento.Text))
            {
                faltanDatos += "Debe completar numero de documento\n";
                txtNroDocumento.Focus();
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                faltanDatos += "Debe completar nombre\n";
                txtNombre.Focus();
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                faltanDatos += "Debe completar apellido\n";
                txtApellido.Focus();
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                faltanDatos += "Debe completar direccion\n";
                txtDireccion.Focus();
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                faltanDatos += "Debe completar email\n";
                txtEmail.Focus();
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                faltanDatos += "Debe completar telefono\n";
                txtTelefono.Focus();
            }
            if (string.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                faltanDatos += "Debe completar nombre usuario\n";
                txtNombreUsuario.Focus();
            }
            if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                faltanDatos += "Debe completar contraseña\n";
                txtContrasena.Focus();
            }
            return faltanDatos;
        }
        protected void btnCancelar2_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
            btnCancelar2.Enabled = false;
            btnModificar.Enabled = false;
            deshabilitarCampos();
            btnGuardar.Enabled = false;
            btnRegistrarSuscripcion.Enabled = false;
            limpiarCampos();
            cboTipoDoc.Enabled = true;
            txtNroDocumento.Enabled = true;
            cboTipoDoc.SelectedIndex = 0;
            txtNroDocumento.Text = "";
        }

        private bool ValidarCampos()
        {

            if (cboTipoDoc.SelectedIndex < 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeValidacion();", true);
                cboTipoDoc.Focus();
                return false;
            }
            if (txtNroDocumento.Text == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeValidacion();", true);
                txtNroDocumento.Focus();
                return false;
            }
            if (txtNombre.Text == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeValidacion();", true);
                //txtNombre.Focus();
                return false;
            }
            if (txtApellido.Text == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeValidacion();", true);
                txtApellido.Focus();
                return false;
            }
            if (txtDireccion.Text == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeValidacion();", true);
                txtDireccion.Focus();
                return false;
            }
            if (txtEmail.Text == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeValidacion();", true);
                txtEmail.Focus();
                return false;
            }
            if (txtTelefono.Text == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeValidacion();", true);
                txtTelefono.Focus();
                return false;
            }
            if (txtNombreUsuario.Text == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeValidacion();", true);
                txtNombreUsuario.Focus();
                return false;
            }
            if (txtContrasena.Text == string.Empty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeValidacion();", true);
                txtContrasena.Focus();
                return false;
            }
            return true;

        }
    }
}