using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPPGODMM1.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {

        [Route("SelectById")]
        [HttpGet]
        public Models.MUsuario SelectById(int Id)
        {
            return new Daos.DaoUsuario().SelectById(Id);
        }
        [Route("SelectByLogin")]
        [HttpGet]
        public Models.MUsuario SelectByLogin(String usuario, String password)
        {
            return new Daos.DaoUsuario().SelectByLogin(usuario , password);
        }
        [Route("SelectAll")]
        [HttpGet]
        public List<Models.MUsuario> SelectAll()
        {
            return new Daos.DaoUsuario().SelectAll();
        }
        [Route("Insert")]
        [HttpPost]
        public int Insert(Models.MUsuario model)
        {
            return new Daos.DaoUsuario().Insert(model);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Models.MUsuario model)
        {
            return new Daos.DaoUsuario().Update(model);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            return new Daos.DaoUsuario().Delete(Id, Usuario, Fecha);
        }
    }
}
