using System;

namespace WebAppPGODMM
{
    public partial class CrearEstado : System.Web.UI.Page
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
                var estado = new Modelos.Estado();
                {
                    estado.EST_NOMBRE = txtNombre.Text;
                    estado.EST_DESCRIPCION = txtDescripcion.Text;
                    estado.EST_CREA = "";
                    estado.EST_ACTUALIZO = "";
                    estado.EST_FECHACREA = DateTime.Now;
                    estado.EST_FECHAACTUA = DateTime.Now;
                    estado.EST_ELIMINO = false;
                };
                new Servicios.EstadoServicio().InsertEstado(estado);
                Response.Redirect("Estados");
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Estados", false);
        }
    }
}