using System;

namespace WebAppPGODMM
{
    public partial class CrearRol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null || (bool)Session["login"] == false)
                    Response.Redirect("Login", false);
                else
                {
                    //cargar info
                }
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var rol = new Modelos.Rol();
                {
                    rol.ROL_NOMBRRE = txtNombre.Text;
                    rol.ROL_DESCRIPCION = txtDescripcion.Text;
                    rol.ROL_CREA = "";
                    rol.ROL_ACTUALIZO = "";
                    rol.ROL_FECHACREA = DateTime.Now;
                    rol.ROL_FECHAACTUA = DateTime.Now;
                    rol.ROL_ELIMINO = false;
                };
                new Servicios.RolServicio().InsertRol(rol);
                Response.Redirect("Roles");
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message.ToString();
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Roles", false);
        }
    }
}