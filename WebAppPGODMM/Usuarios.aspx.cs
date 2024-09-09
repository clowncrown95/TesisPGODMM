using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class Usuarios : System.Web.UI.Page
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
            List<Modelos.Usuario> listaUsuario = new List<Modelos.Usuario>();

            listaUsuario = new Servicios.UsuarioServicio().FindAllU();
            gvDatos.DataSource = listaUsuario;
            gvDatos.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInformacion();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearUsuario");
        }

        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Session["USU_ID"] = Convert.ToInt32(e.CommandArgument.ToString());

            if (e.CommandName.Equals("edit"))
            {
                int usuId = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.usuarioId] = usuId;
                Response.Redirect("EditarUsuario");
            }
            if (e.CommandName.Equals("delete"))
            {
                int usuId = Convert.ToInt32(e.CommandArgument.ToString());
                Session[Shared.Constantes.usuarioId] = usuId;
                Response.Redirect("EliminarUsuario");
            }
        }
    }
}