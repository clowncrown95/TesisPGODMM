using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppPGODMM.Modelos;

namespace WebAppPGODMM
{
    public partial class EditarEquipo : System.Web.UI.Page
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
                            ddlTipoCategoria.SelectedValue = equipo.CAT_ID.ToString();
                            txtNombre.Text = equipo.EQU_NOMBRE;
                            txtCodigo.Text = equipo.EQU_CODIGO;
                            txtDescripcion.Text = equipo.EQU_DESCRIPCION;
                            txtTiempo.Text = equipo.EQU_TIEMPO.ToString();
                            txtCosto.Text = equipo.EQU_COSTO.ToString();
                        }
                    }
                }
                CargarCategorias();
            }

        }

        private void CargarCategorias()
        {
            var categorias = ObtenerCategorias();
            ddlTipoCategoria.Items.Clear();
            ddlTipoCategoria.Items.Add(new ListItem("Seleccione una Categoria", ""));

            foreach (var categoria in categorias)
            {
                ddlTipoCategoria.Items.Add(new ListItem(categoria.CAT_NOMBRE, categoria.CAT_ID.ToString()));
            }
        }

        private List<Modelos.Categoria> ObtenerCategorias()
        {
            List<Modelos.Categoria> listaCategoria = new List<Modelos.Categoria>();

            listaCategoria = new Servicios.CategoriaServicio().FindListCategoria();
            return listaCategoria;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var nombreUsu = new Modelos.Usuario().USU_USUARIO;
                var equipo = new Modelos.Equipo
                {
                    EQU_ID = int.Parse(lblEquipoId.Value),
                    CAT_ID = int.Parse(ddlTipoCategoria.SelectedValue),
                    EQU_NOMBRE = txtNombre.Text,
                    EQU_CODIGO = txtCodigo.Text,
                    EQU_DESCRIPCION = txtDescripcion.Text,
                    EQU_TIEMPO = int.Parse(txtTiempo.Text),
                    EQU_COSTO = int.Parse(txtCosto.Text),               
                    EQU_ACTUALIZO = nombreUsu,
                    EQU_FECHAACTUA = DateTime.Now,
                };

                new Servicios.EquipoServicio().UpdateEquipo(equipo);
                lblError.Text = "Equipo actualizado correctamente";
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
