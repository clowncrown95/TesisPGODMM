using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class EditarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Shared.Constantes.usuarioId] != null)
                {
                    var Id = (int)Session[Shared.Constantes.usuarioId];
                    if (Id > 0)
                    {
                        int usuarioId = Id;
                        var usuario = new Servicios.UsuarioServicio().GetUser(usuarioId);
                        if (usuario != null)
                        {
                            lblUsuaId.Value = usuario.USU_ID.ToString();
                            ddlTRol.SelectedValue = usuario.ROL_ID.ToString();
                            txtUsuario.Text = usuario.USU_USUARIO;
                            txtPassword.Text = usuario.USU_PASSWORD;
                            txtEstado.Text = usuario.USU_ESTADO;
                        }
                    }
                }
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
                var nombreUsu = new Modelos.Usuario().USU_USUARIO;
                var usuario = new Modelos.Usuario
                {
                    USU_ID = int.Parse(lblUsuaId.Value),
                    ROL_ID = int.Parse(ddlTRol.SelectedValue),
                    USU_USUARIO = txtUsuario.Text,
                    USU_PASSWORD = txtPassword.Text,
                    USU_ESTADO = txtEstado.Text,
                    USU_ACTUALIZO = nombreUsu,
                    USU_FECHAACTUA = DateTime.Now,
                };

                new Servicios.UsuarioServicio().UpdateUser(usuario);
                lblError.Text = "Usuario actualizado correctamente";
                Response.Redirect("Usuarios", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios", false);
        }
    }
}