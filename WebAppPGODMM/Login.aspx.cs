using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebAppPGODMM
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Modelos.Usuario usuario = new Modelos.Usuario();
            usuario = new Servicios.UsuarioServicio().GetLoginUser(txtCorreoElectronico.Text, txtContrasenia.Text);
            if (usuario.USU_ID > 0)
            {
                Session["usuarioLogin"] = usuario;
                Session["login"] = true;
                Response.Redirect("~/Default", false);
            }
            else
            {
                MessageBox.Show("El Usuario o Password son incorrectos.","Error Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}