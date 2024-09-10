using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class OrdenesTrabajo : System.Web.UI.Page
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
            List<Modelos.DTOM.DTOOrdTra> listaOrdenTrabajo = new List<Modelos.DTOM.DTOOrdTra>();

            listaOrdenTrabajo = new Servicios.DtoServicio.DtoCompartidoServicio().FindAllOrder();
            gvDatos.DataSource = listaOrdenTrabajo;
            gvDatos.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearOT");
        }

        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session["ORD_ID"] = Convert.ToInt32(e.CommandArgument.ToString());

            if (e.CommandName.Equals("edit"))
            {
                int ordId = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.ordenesId] = ordId;
                Response.Redirect("EditarOT");
            }
            if (e.CommandName.Equals("delete"))
            {
                int ordId = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.ordenesId] = ordId;
                Response.Redirect("EliminarOT");
            }
        }
    }
}