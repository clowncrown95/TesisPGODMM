using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppPGODMM
{
    public partial class EditarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Shared.Constantes.catId] != null)
                {
                    var Id = (int)Session[Shared.Constantes.catId];
                    if (Id > 0)
                    {
                        int catId = Id;
                        var categoria = new Servicios.CategoriaServicio().GetCategoria(catId);
                        if (categoria != null)
                        {
                            lblCatId.Value = categoria.CAT_ID.ToString();
                            txtNombre.Text = categoria.CAT_NOMBRE;
                            txtDescripcion.Text = categoria.CAT_DESCRIPCION;
                            txtPorcentaje.Text = categoria.CAT_PORCENTAJE.ToString();
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
                var categoria = new Modelos.Categoria
                {
                    CAT_ID = int.Parse(lblCatId.Value),
                    CAT_NOMBRE = txtNombre.Text,
                    CAT_DESCRIPCION = txtDescripcion.Text,
                    CAT_PORCENTAJE = int.Parse(txtPorcentaje.Text),
                    CAT_ACTUALIZO = nombreUsu,
                    CAT_FECHAACTUA = DateTime.Now,
                };

                new Servicios.CategoriaServicio().UpdateCategoria(categoria);
                lblError.Text = "Categoria actualizada correctamente";
                Response.Redirect("Categorias", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias", false);
        }
    }
}