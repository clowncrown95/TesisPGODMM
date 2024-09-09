using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class Locales : System.Web.UI.Page
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
            List<Modelos.Local> listaLocal = new List<Modelos.Local>();

            listaLocal = new Servicios.LocalServicio().FindAllLocal();
            gvDatos.DataSource = listaLocal;
            gvDatos.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearLocal");
        }
        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session["LOC_ID"] = Convert.ToInt32(e.CommandArgument.ToString());

            if (e.CommandName.Equals("edit"))
            {
                int locID = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.localId] = locID;
                Response.Redirect("EditarLocal");
            }
            if (e.CommandName.Equals("delete"))
            {
                int locID = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.localId] = locID;
                Response.Redirect("EliminarLocal");
            }
        }
    }
}