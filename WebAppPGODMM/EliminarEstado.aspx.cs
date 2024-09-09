using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class EliminarEstado : System.Web.UI.Page
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
                var FechaAct = DateTime.Now;
                var Id = new Modelos.Cargo().CAR_ID = int.Parse(lblEstadoId.Value);

                new Servicios.EstadoServicio().DeleteEstado(Id, nombreUsu, FechaAct);
                lblError.Text = "Estado Eliminado";
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