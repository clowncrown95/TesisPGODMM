using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApiPPGODMM1.Daos;

namespace WebAppPGODMM
{
    public partial class EliminarPersona : System.Web.UI.Page
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
                            txtApellido.Text = persona.PER_APELLIDO;
                            txtNombre.Text = persona.PER_NOMBRE;
                            txtCedula.Text = persona.PER_CEDULA;
                            txtDireccion.Text = persona.PER_DIRECCION;
                            txtTelefono.Text = persona.PER_TELEFONO.ToString();
                            txtCorreo.Text = persona.PER_CORREO;
                        }
                    }
                }
            }
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var nombreUsu = new Modelos.Usuario().USU_USUARIO;
                var FechaAct = DateTime.Now;
                var Id = new Modelos.Persona().PER_ID = int.Parse(lblPersonaId.Value);

                new Servicios.PersonaServicio().DeletePersona(Id, nombreUsu, FechaAct);
                lblError.Text = "Persona Eliminada";
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