using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class Cargos : System.Web.UI.Page
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
            List<Modelos.Cargo> listaCargo = new List<Modelos.Cargo>();

            listaCargo = new Servicios.CargoServicio().FindAllCargo();
            gvDatos.DataSource = listaCargo;
            gvDatos.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearCargo");
        }
        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session["CAR_ID"] = Convert.ToInt32(e.CommandArgument.ToString());

            if (e.CommandName.Equals("detail"))
            {
                Response.Redirect("CargoDetalles");
            }
            if (e.CommandName.Equals("edit"))
            {
                Response.Redirect("CargoEditar");
            }
            if (e.CommandName.Equals("delete"))
            {
                Response.Redirect("CargoEliminar");
            }
        }
    }
}