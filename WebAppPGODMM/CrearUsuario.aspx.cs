using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApiPPGODMM1;

namespace WebAppPGODMM
{
    public partial class CrearUsuario : System.Web.UI.Page
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
        private bool Validar()
        {
           bool resultado = true;
            /*Modelos.Usuario usuarioLogin = (Modelos.Usuario)Session["usuarioLogin"];
            var existe = WebApiPPGODMM1.Daos.DaoUsuario.SelectById(usuarioLogin.USU_ID);
            //Datos.Proceso.DaoProducto.ObtenerPorUsuarioProCodigo(usuarioLogin.USU_ID, txtCodigo.Text); 
            if (existe.USU_ID > 0)
            {
                lblResultado.Text = "El Código de producto ya existe";
                resultado = false;
            }*/
            return resultado;
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            try
            {
                /*Modelos.Usuario usuarioLogin = (Modelos.Usuario)Session["usuarioLogin"];
                Modelos.Usuario usuario = new Modelos.Usuario
                {
                    ROL_ID = ,
                    PER_ID = ,
                    USU_USUARIO = ,
                    USU_PASSWORD = ,
                    USU_ESTADO = ,
                    USU_CREO = ,
                    USU_ACTUALIZO = ,
                    USU_FECHACREA = GetDate(),
                    USU_FECHAACTUA = GetDate(),
                    USU_ELIMINO = 0,
                };
               var i = WebApiPPGODMM1.Daos.DaoUsuario.Insert(usuario);*/
               /*if (i > 0)
                    lblResultado.Text = "Datos grabados";
                else
                    lblResultado.Text = "Intente de nuevo";*/
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios", false);
        }
    }
}