using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class CrearPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null || (bool)Session["login"] == false)
                    Response.Redirect("Login", false);

                CargarCargo();
                CargarUsuario();
            }
        }

        private void CargarCargo()
        {
            var cargos = ObtenerCargos();
            ddlCargo.Items.Clear();
            ddlCargo.Items.Add(new ListItem("Seleccione un Cargo", ""));

            foreach (var cargo in cargos)
            {
                ddlCargo.Items.Add(new ListItem(cargo.CAR_NOMBRE, cargo.CAR_ID.ToString()));
            }
        }

        private List<Modelos.Cargo> ObtenerCargos()
        {
            List<Modelos.Cargo> listaCargo = new List<Modelos.Cargo>();

            listaCargo = new Servicios.CargoServicio().FindListCargo();
            return listaCargo;
        }

        private void CargarUsuario()
        {
            var usuarios = ObtenerUsuarios();
            ddlUsuario.Items.Clear();
            ddlUsuario.Items.Add(new ListItem("Seleccione un Usuario", ""));

            foreach (var usuario in usuarios)
            {
                ddlUsuario.Items.Add(new ListItem(usuario.USU_USUARIO, usuario.USU_ID.ToString()));
            }
        }

        private List<Modelos.Usuario> ObtenerUsuarios()
        {
            List<Modelos.Usuario> listaUsuario = new List<Modelos.Usuario>();

            listaUsuario = new Servicios.UsuarioServicio().FindListUsuario();
            return listaUsuario;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var persona = new Modelos.Persona();
                {
                    persona.CAR_ID = int.Parse(ddlCargo.SelectedValue);
                    persona.USU_ID = int.Parse(ddlCargo.SelectedValue);
                    persona.PER_APELLIDO = txtNombre.Text;
                    persona.PER_NOMBRE = txtNombre.Text;
                    persona.PER_CEDULA = txtCedula.Text;
                    persona.PER_DIRECCION = txtDireccion.Text;
                    persona.PER_TELEFONO = int.Parse(txtTelefono.Text);
                    persona.PER_CORREO = txtCorreo.Text;
                    persona.PER_CREO = "";
                    persona.PER_ACTUALIZO = "";
                    persona.PER_FECHACREA = DateTime.Now;
                    persona.PER_FECHAACTUA = DateTime.Now;
                    persona.PER_ELIMINO = false;
                };
                new Servicios.PersonaServicio().InsertPersona(persona);
                Response.Redirect("Personas");
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personas", false);
        }
    }
}