using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class CrearCategoria : System.Web.UI.Page
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
                var categoria = new Modelos.Categoria();
                {
                    categoria.CAT_NOMBRE = txtNombre.Text;
                    categoria.CAT_DESCRIPCION = txtDescripcion.Text;
                    categoria.CAT_PORCENTAJE = int.Parse(txtPorcentaje.Text);
                    categoria.CAT_CREO = "";
                    categoria.CAT_ACTUALIZO = "";
                    categoria.CAT_FECHACREO = DateTime.Now;
                    categoria.CAT_FECHAACTUA = DateTime.Now;
                    categoria.CAT_ELIMINO = false;
                };
                new Servicios.CategoriaServicio().InsertCategoria(categoria);
                Response.Redirect("Categorias");
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias", false);
        }
    }
}