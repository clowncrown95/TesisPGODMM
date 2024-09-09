using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class CrearEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null || (bool)Session["login"] == false)
                    Response.Redirect("Login", false);

                CargarCategorias();
            }
        }

        private void CargarCategorias()
        {
            var categorias = ObtenerCategorias();
            ddlTipoCategoria.Items.Clear();
            ddlTipoCategoria.Items.Add(new ListItem("Seleccione una Categoria",""));

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
                var equipo = new Modelos.Equipo();
                {
                    equipo.CAT_ID = int.Parse(ddlTipoCategoria.SelectedValue);
                    equipo.EQU_NOMBRE = txtNombre.Text;
                    equipo.EQU_CODIGO = txtCodigo.Text; 
                    equipo.EQU_DESCRIPCION = txtDescripcion.Text;
                    equipo.EQU_TIEMPO = int.Parse(txtTiempo.Text);
                    equipo.EQU_COSTO = int.Parse(txtCosto.Text);
                    equipo.EQU_CREA = "";
                    equipo.EQU_ACTUALIZO = "";
                    equipo.EQU_FECHACREA = DateTime.Now;
                    equipo.EQU_FECHAACTUA = DateTime.Now;
                    equipo.EQU_ELIMINO = false;
                };
                new Servicios.EquipoServicio().InsertEquipo(equipo);
                Response.Redirect("Equipos");
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Equipos", false);
        }
    }
}