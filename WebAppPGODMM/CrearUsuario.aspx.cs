using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class CrearUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null || (bool)Session["login"] == false)
                    Response.Redirect("Login", false);

                CargarRoles();
            }
        }

        private void CargarRoles()
        {
            var roles = ObtenerRoles();
            ddlTRol.Items.Clear();
            ddlTRol.Items.Add(new ListItem("Seleccione un Rol", ""));

            foreach (var rol in roles)
            {
                ddlTRol.Items.Add(new ListItem(rol.ROL_NOMBRRE, rol.ROL_ID.ToString()));
            }
        }

        private List<Modelos.Rol> ObtenerRoles()
        {
            List<Modelos.Rol> listaRol = new List<Modelos.Rol>();

            listaRol = new Servicios.RolServicio().FindListRol();
            return listaRol;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = new Modelos.Usuario();
                {
                    usuario.ROL_ID = int.Parse(ddlTRol.SelectedValue);
                    usuario.USU_USUARIO = txtUsuario.Text;
                    usuario.USU_PASSWORD = txtPassword.Text;
                    usuario.USU_ESTADO = txtEstado.Text;
                    usuario.USU_CREO = "";
                    usuario.USU_ACTUALIZO = "";
                    usuario.USU_FECHACREA = DateTime.Now;
                    usuario.USU_FECHAACTUA = DateTime.Now;
                    usuario.USU_ELIMINO = false;
                };
                new Servicios.UsuarioServicio().InsertUser(usuario);
                Response.Redirect("Usuarios");
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios", false);
        }
    }
}