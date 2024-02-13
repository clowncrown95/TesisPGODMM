using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class Tecnicos : System.Web.UI.Page
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
            List<Modelos.RTecnico> listaRtecnico = new List<Modelos.RTecnico>();

            listaRtecnico = new Servicios.RTecnicoServicio().FindAllRTecnico();
            gvDatos.DataSource = listaRtecnico;
            gvDatos.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearRtecnico");
        }
        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session["RTEC_ID"] = Convert.ToInt32(e.CommandArgument.ToString());

            if (e.CommandName.Equals("detail"))
            {
                Response.Redirect("RtecnicoDetalles");
            }
            if (e.CommandName.Equals("edit"))
            {
                Response.Redirect("RtecnicoEditar");
            }
            if (e.CommandName.Equals("delete"))
            {
                Response.Redirect("RtecnicoEliminar");
            }
        }
    }
}