using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class Equipos : System.Web.UI.Page
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
            List<Modelos.Equipo> listaEquipo = new List<Modelos.Equipo>();

            listaEquipo = new Servicios.EquipoServicio().FindAllEquipo();
            gvDatos.DataSource = listaEquipo;
            gvDatos.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearEquipo");
        }
        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session["EQU_ID"] = Convert.ToInt32(e.CommandArgument.ToString());

            if (e.CommandName.Equals("detail"))
            {
                Response.Redirect("EquipoDetalles");
            }
            if (e.CommandName.Equals("edit"))
            {
                Response.Redirect("EquipoEditar");
            }
            if (e.CommandName.Equals("delete"))
            {
                Response.Redirect("EquipoEliminar");
            }
        }
    }
}