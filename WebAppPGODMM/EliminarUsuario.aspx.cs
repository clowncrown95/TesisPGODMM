using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class EliminarUsuario : System.Web.UI.Page
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
                            txtUsuario.Text = usuario.USU_USUARIO;
                            txtPassword.Text = usuario.USU_PASSWORD;
                            txtEstado.Text = usuario.USU_ESTADO;
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
                var Id = new Modelos.Usuario().USU_ID = int.Parse(lblUsuaId.Value);

                new Servicios.UsuarioServicio().DeleteUser(Id, nombreUsu, FechaAct);
                lblError.Text = "Usuario Eliminado";
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