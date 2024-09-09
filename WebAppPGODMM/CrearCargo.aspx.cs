using System;

namespace WebAppPGODMM
{
    public partial class CrearCargo : System.Web.UI.Page
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
                var cargo = new Modelos.Cargo();
                {
                    cargo.CAR_NOMBRE = txtNombre.Text;
                    cargo.CAR_DESCRIPCION = txtDescripcion.Text;
                    cargo.CAR_CREO = "";
                    cargo.CAR_ACTUALIZO = "";
                    cargo.CAR_FECHACREA = DateTime.Now;
                    cargo.CAR_FECHAACTUA = DateTime.Now;
                    cargo.CAR_ELIMINO = false;
                };
                new Servicios.CargoServicio().InsertCargo(cargo);
                Response.Redirect("Cargos");
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cargos", false);
        }
    }
}