using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class EliminarCargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Shared.Constantes.cargoId] != null)
                {
                    var Id = (int)Session[Shared.Constantes.cargoId];
                    if (Id > 0)
                    {
                        int cargoId = Id;
                        var cargo = new Servicios.CargoServicio().GetCargo(cargoId);
                        if (cargo != null)
                        {
                            lblCargoId.Value = cargo.CAR_ID.ToString();
                            txtNombre.Text = cargo.CAR_NOMBRE;
                            txtDescripcion.Text = cargo.CAR_DESCRIPCION;
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
                var Id = new Modelos.Cargo().CAR_ID = int.Parse(lblCargoId.Value);

                new Servicios.CargoServicio().DeleteCargo(Id, nombreUsu, FechaAct);
                lblError.Text = "Cargo Eliminado";
                Response.Redirect("Cargos", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cargos", false);
        }

    }
}