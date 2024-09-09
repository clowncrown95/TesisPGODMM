using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class Roles : System.Web.UI.Page
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
            List<Modelos.Rol> listaRol = new List<Modelos.Rol>();

            listaRol = new Servicios.RolServicio().FindAllRol();
            gvDatos.DataSource = listaRol;
            gvDatos.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearRol");
        }
        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session["ROL_ID"] = Convert.ToInt32(e.CommandArgument.ToString());

            if (e.CommandName.Equals("edit"))
            {
                int rolID = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.rolId] = rolID;
                Response.Redirect("EditarRol");
            }
            if (e.CommandName.Equals("delete"))
            {
                int rolID = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.rolId] = rolID;
                Response.Redirect("EliminarRol");
            }
        }
    }
}