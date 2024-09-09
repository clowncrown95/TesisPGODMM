using System;

namespace WebAppPGODMM
{
    public partial class EditarEstado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Shared.Constantes.estadoId] != null)
                {
                    var Id = (int)Session[Shared.Constantes.estadoId];
                    if (Id > 0)
                    {
                        int estadoId = Id;
                        var estado = new Servicios.EstadoServicio().GetEstado(estadoId);
                        if (estado != null)
                        {
                            lblEstadoId.Value = estado.EST_ID.ToString();
                            txtNombre.Text = estado.EST_NOMBRE;
                            txtDescripcion.Text = estado.EST_DESCRIPCION;
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
                var estado = new Modelos.Estado
                {
                    EST_ID = int.Parse(lblEstadoId.Value),
                    EST_NOMBRE = txtNombre.Text,
                    EST_DESCRIPCION = txtDescripcion.Text,
                    EST_ACTUALIZO = nombreUsu,
                    EST_FECHAACTUA = DateTime.Now,
                };

                new Servicios.EstadoServicio().UpdateEstado(estado);
                lblError.Text = "Estado actualizado correctamente";
                Response.Redirect("Estados", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Estados", false);
        }
    }
}