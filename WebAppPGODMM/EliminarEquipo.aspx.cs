using System;

namespace WebAppPGODMM
{
    public partial class EliminarEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Shared.Constantes.equipoId] != null)
                {
                    var Id = (int)Session[Shared.Constantes.equipoId];
                    if (Id > 0)
                    {
                        int equipoId = Id;
                        var equipo = new Servicios.EquipoServicio().GetEquipo(equipoId);
                        if (equipo != null)
                        {
                            lblEquipoId.Value = equipo.EQU_ID.ToString();
                            txtNombre.Text = equipo.EQU_NOMBRE;
                            txtCodigo.Text = equipo.EQU_CODIGO;
                            txtDescripcion.Text = equipo.EQU_DESCRIPCION;
                            txtTiempo.Text = equipo.EQU_TIEMPO.ToString();
                            txtCosto.Text = equipo.EQU_COSTO.ToString();
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
                var Id = new Modelos.Equipo().EQU_ID = int.Parse(lblEquipoId.Value);

                new Servicios.EquipoServicio().DeleteEquipo(Id, nombreUsu, FechaAct);
                lblError.Text = "Equipo Eliminado";
                Response.Redirect("Equipos", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Equipos", false);
        }
    }
}