using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class EditarPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Shared.Constantes.persoId] != null)
                {
                    var Id = (int)Session[Shared.Constantes.persoId];
                    if (Id > 0)
                    {
                        int persoId = Id;
                        var persona = new Servicios.PersonaServicio().GetPersona(persoId);
                        if (persona != null)
                        {
                            lblPersonaId.Value = persona.PER_ID.ToString();
                            ddlCargo.SelectedValue = persona.CAR_ID.ToString();
                            ddlUsuario.SelectedValue = persona.USU_ID.ToString();
                            txtApellido.Text = persona.PER_APELLIDO;
                            txtNombre.Text = persona.PER_NOMBRE;
                            txtCedula.Text = persona.PER_CEDULA;
                            txtDireccion.Text = persona.PER_DIRECCION;
                            txtTelefono.Text = persona.PER_TELEFONO.ToString();
                            txtCorreo.Text = persona.PER_CORREO;
                        }
                    }
                }
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
                var nombreUsu = new Modelos.Usuario().USU_USUARIO;
                var persona = new Modelos.Persona
                {
                    PER_ID = int.Parse(lblPersonaId.Value),
                    CAR_ID = int.Parse(ddlCargo.SelectedValue),
                    USU_ID = int.Parse(ddlUsuario.SelectedValue),
                    PER_APELLIDO = txtApellido.Text,
                    PER_NOMBRE = txtNombre.Text,
                    PER_CEDULA = txtCedula.Text,
                    PER_DIRECCION = txtDireccion.Text,
                    PER_TELEFONO = int.Parse(txtTelefono.Text),
                    PER_CORREO = txtCorreo.Text,
                    PER_ACTUALIZO = nombreUsu,
                    PER_FECHAACTUA = DateTime.Now,
                };

                new Servicios.PersonaServicio().UpdatePersona(persona);
                lblError.Text = "Persona actualizada correctamente";
                Response.Redirect("Personas", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personas", false);
        }
    }
}