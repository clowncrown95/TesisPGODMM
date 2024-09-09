using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class CrearLocal : System.Web.UI.Page
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
                var local = new Modelos.Local();
                {
                    local.LOC_NOMBRE = txtNombre.Text;
                    local.LOC_NUMERO = int.Parse(txtNumero.Text);
                    local.LOC_CREO = "";
                    local.LOC_ACTUALIZO = "";
                    local.LOC_FECHACREA = DateTime.Now;
                    local.LOC_FECHAACTUA = DateTime.Now;
                    local.LOC_ELIMINO = false;
                };
                new Servicios.LocalServicio().InsertLocal(local);
                Response.Redirect("Locales");
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message.ToString();
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Locales", false);
        }

    }       
}