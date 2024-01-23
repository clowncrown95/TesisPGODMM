using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null || (bool)Session["login"] == false)
                    Response.Redirect("Login", false);
                else
                {
                    CargarInformacion();
                }
            }
        }
        private void CargarInformacion()
        {
            /*var user = new Modelos.Usuario();
            user = (Modelos.Usuario)Session["usuarioLogin"];
            btnUsuarioLogin.Text = $"<span class='glyphicon glyphicon-user' aria-hidden='true'></span> {user.NOMBRES} <span class='caret'></span>";*/
        }
    }
}