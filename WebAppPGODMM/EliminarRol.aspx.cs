using System;

namespace WebAppPGODMM
{
    public partial class EliminarRol : System.Web.UI.Page
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
                var FechaAct = DateTime.Now;
                var Id = new Modelos.Rol().ROL_ID = int.Parse(lblRolId.Value);

                new Servicios.RolServicio().DeleteRol(Id, nombreUsu, FechaAct);
                lblError.Text = "Rol Eliminado";
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