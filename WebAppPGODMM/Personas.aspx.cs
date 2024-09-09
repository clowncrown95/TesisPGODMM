using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class Personas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null || (bool)Session["login"] == false)
                    Response.Redirect("Login");
                else
                {
                    CargarInformacion();
                }

            }

        }
        private void CargarInformacion()
        {
            /*List<Modelos.DTOM.DTOPerCom> listaPersona = new List<Modelos.DTOM.DTOPerCom>();

            listaPersona = new Servicios.DtoServicio.DtoCompartidoServicio().FindAllPersonas();
            gvDatos.DataSource = listaPersona;
            gvDatos.DataBind();*/
            List<Modelos.Persona> listaPersona = new List<Modelos.Persona>();

            listaPersona = new Servicios.PersonaServicio().FindAllPersona();
            gvDatos.DataSource = listaPersona;
            gvDatos.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearPersona");
        }

        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session["PER_ID"] = Convert.ToInt32(e.CommandArgument.ToString());

            if (e.CommandName.Equals("edit"))
            {
                int perId = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.persoId] = perId;
                Response.Redirect("EditarPersona");
            }
            if (e.CommandName.Equals("delete"))
            {
                int perId = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.persoId] = perId;
                Response.Redirect("EliminarPersona");
            }
        }
    }
}