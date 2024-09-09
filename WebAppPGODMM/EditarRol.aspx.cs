using System;

namespace WebAppPGODMM
{
    public partial class EditarRol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Shared.Constantes.rolId] != null)
                {
                    var Id = (int)Session[Shared.Constantes.rolId];
                    if (Id > 0)
                    {
                        int rolId = Id;
                        var rol = new Servicios.RolServicio().GetRol(rolId);
                        if (rol != null)
                        {
                            lblRolId.Value = rol.ROL_ID.ToString();
                            txtNombre.Text = rol.ROL_NOMBRRE;
                            txtDescripcion.Text = rol.ROL_DESCRIPCION;
                        }
                    }

                }

            }

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var nombreUsu = new Modelos.Usuario().USU_USUARIO;
                var rol = new Modelos.Rol
                {
                    ROL_ID = int.Parse(lblRolId.Value),
                    ROL_NOMBRRE = txtNombre.Text,
                    ROL_DESCRIPCION = txtDescripcion.Text,
                    ROL_ACTUALIZO = nombreUsu,
                    ROL_FECHAACTUA = DateTime.Now,
                };

                new Servicios.RolServicio().UpdateRol(rol);
                lblError.Text = "Rol actualizado correctamente";
                Response.Redirect("Roles", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Roles", false);
        }
    }
}