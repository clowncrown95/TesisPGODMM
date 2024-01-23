using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

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
            List<Modelos.DTOM.DTOUsuCom> listaUsuario = new List<Modelos.DTOM.DTOUsuCom>();

            listaUsuario = new Servicios.DtoServicio.DtoCompartidoServicio().FindAllUser();
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

            if (e.CommandName.Equals("detail"))
            {
                Response.Redirect("UsuarioDetalles");
            }
            if (e.CommandName.Equals("edit"))
            {
                Response.Redirect("UsuarioEditar");
            }
            if (e.CommandName.Equals("delete"))
            {
                Response.Redirect("UsuarioEliminar");
            }
        }
    }
}