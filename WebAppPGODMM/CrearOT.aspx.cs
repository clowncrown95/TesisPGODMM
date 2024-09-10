using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApiPPGODMM1.Daos;

namespace WebAppPGODMM
{
    public partial class CrearOT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null || (bool)Session["login"] == false)
                    Response.Redirect("Login", false);

                CargarLocal();
                CargarUsuario();
                CargarEquipo();
                CargarEstado();
            }
        }
        //Locales
        private void CargarLocal()
        {
            var locales = ObtenerLocales();
            ddlLocal.Items.Clear();
            ddlLocal.Items.Add(new ListItem("Seleccione un Local", ""));

            foreach (var local in locales)
            {
                ddlLocal.Items.Add(new ListItem(local.LOC_NOMBRE, local.LOC_ID.ToString()));
            }
        }

        private List<Modelos.Local> ObtenerLocales()
        {
            List<Modelos.Local> listaLocal = new List<Modelos.Local>();

            listaLocal = new Servicios.LocalServicio().FindListLocal();
            return listaLocal;
        }
        //Usuarios
        private void CargarUsuario()
        {
            var usuarios = ObtenerUsuarios();
            ddlUsuario.Items.Clear();
            ddlUsuario.Items.Add(new ListItem("Seleccione un Usuario", ""));

            foreach (var usuario in usuarios)
            {
                ddlUsuario.Items.Add(new ListItem(usuario.USU_USUARIO, usuario.USU_ID.ToString()));
            }
        }
        private List<Modelos.Usuario> ObtenerUsuarios()
        {
            List<Modelos.Usuario> listaUsuario = new List<Modelos.Usuario>();

            listaUsuario = new Servicios.UsuarioServicio().FindListUsuario();
            return listaUsuario;
        }
        //Equipos
        private void CargarEquipo()
        {
            var equipos = ObtenerEquipos();
            ddlEquipo.Items.Clear();
            ddlEquipo.Items.Add(new ListItem("Seleccione un Equipo", ""));

            foreach (var equipo in equipos)
            {
                ddlEquipo.Items.Add(new ListItem(equipo.EQU_NOMBRE, equipo.EQU_ID.ToString()));
            }
        }
        private List<Modelos.Equipo> ObtenerEquipos()
        {
            List<Modelos.Equipo> listaEquipo = new List<Modelos.Equipo>();

            listaEquipo = new Servicios.EquipoServicio().FindListEquipo();
            return listaEquipo;
        }
        //Estados
        private void CargarEstado()
        {
            var estados = ObtenerEstados();
            ddlEstado.Items.Clear();
            ddlEstado.Items.Add(new ListItem("Seleccione un Estado", ""));

            foreach (var estado in estados)
            {
                ddlEstado.Items.Add(new ListItem(estado.EST_NOMBRE, estado.EST_ID.ToString()));
            }
        }
        private List<Modelos.Estado> ObtenerEstados()
        {
            List<Modelos.Estado> listaEstado = new List<Modelos.Estado>();

            listaEstado = new Servicios.EstadoServicio().FindListEstado();
            return listaEstado;
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var ordtra = new Modelos.DTOM.DTOOrdTra();
                {
                    ordtra.LOC_NOMBRE = int.Parse(ddlLocal.SelectedValue);
                    ordtra.USU_USUARIO = int.Parse(ddlUsuario.SelectedValue);
                    ordtra.ORD_FECHAINI = DateTime.Parse(Fini.Text);
                    ordtra.ORD_FECHAFIN = DateTime.Parse(Ffin.Text); ;
                    ordtra.ORD_NUMERO = int.Parse(txtNumOrd.Text);
                    ordtra.EQU_NOMBRE = int.Parse(ddlEquipo.SelectedValue);
                    ordtra.DTOR_DETALLE = txtDetalle.Text;
                    ordtra.RTEC_DESCIPCION = txtdesTec.Text;
                    ordtra.RTEC_RESPALDO = txtresTec.Text;
                    ordtra.RTEC_COSTO = int.Parse(txtcosTec.Text);
                    ordtra.RTEC_FIRMA = txtfirTec.Text;
                };
                new Servicios.DtoServicio.DtoCompartidoServicio().InsertOT(ordtra);
                Response.Redirect("OrdenesTrabajo");
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message.ToString();
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdenesTrabajo", false);
        }
    }
}

