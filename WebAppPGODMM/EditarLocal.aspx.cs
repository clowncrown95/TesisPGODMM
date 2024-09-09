using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class EditarLocal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Shared.Constantes.localId] != null)
                {
                    var Id = (int)Session[Shared.Constantes.localId];
                    if (Id > 0)
                    {
                        int localId = Id;
                        var local = new Servicios.LocalServicio().GetLocal(localId);
                        if (local != null)
                        {
                            lblLocalId.Value = local.LOC_ID.ToString();
                            txtNombre.Text = local.LOC_NOMBRE;
                            txtNumero.Text = local.LOC_NUMERO.ToString();
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
                var local = new Modelos.Local
                {
                    LOC_ID = int.Parse(lblLocalId.Value),
                    LOC_NOMBRE = txtNombre.Text,
                    LOC_NUMERO = int.Parse(txtNumero.Text),
                    LOC_ACTUALIZO = nombreUsu,
                    LOC_FECHAACTUA = DateTime.Now,
                };

                new Servicios.LocalServicio().UpdateLocal(local);
                lblError.Text = "Local actualizado correctamente";
                Response.Redirect("Locales", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Locales", false);
        }
    }
}