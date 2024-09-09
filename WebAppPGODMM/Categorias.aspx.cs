using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class Categorias : System.Web.UI.Page
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
            List<Modelos.Categoria> listaCategoria = new List<Modelos.Categoria>();

            listaCategoria = new Servicios.CategoriaServicio().FindAllCategoria();
            gvDatos.DataSource = listaCategoria;
            gvDatos.DataBind();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearCategoria");
        }
        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session["CAT_ID"] = Convert.ToInt32(e.CommandArgument.ToString());

            if (e.CommandName.Equals("edit"))
            {
                int catID = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.catId] = catID;
                Response.Redirect("EditarCategoria");
            }
            if (e.CommandName.Equals("delete"))
            {
                int catID = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.catId] = catID;
                Response.Redirect("EliminarCategoria");
            }
        }
    }
}