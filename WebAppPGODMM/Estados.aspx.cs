using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class Estados : System.Web.UI.Page
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
            List<Modelos.Estado> listaEstado = new List<Modelos.Estado>();

            listaEstado = new Servicios.EstadoServicio().FindAllEstado();
            gvDatos.DataSource = listaEstado;
            gvDatos.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearEstado");
        }
        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session["EST_ID"] = Convert.ToInt32(e.CommandArgument.ToString());

            if (e.CommandName.Equals("edit"))
            {
                int estID = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.estadoId] = estID;
                Response.Redirect("EditarEstado");
            }
            if (e.CommandName.Equals("delete"))
            {
                int estID = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.estadoId] = estID;
                Response.Redirect("EliminarEstado");
            }
        }
    }
}