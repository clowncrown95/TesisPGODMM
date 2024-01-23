using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPPGODMM1.Controllers
{
    [RoutePrefix("api/Rol")]
    public class RolController : ApiController
    {

        [Route("SelectById")]
        [HttpGet]
        public Models.MRol SelectById(int Id)
        {
            return new Daos.DaoRol().SelectById(Id);
        }
        [Route("SelectAll")]
        [HttpGet]
        public List<Models.MRol> SelectAll()
        {
            return new Daos.DaoRol().SelectAll();
        }
        [Route("Insert")]
        [HttpPost]
        public int Insert(Models.MRol model)
        {
            return new Daos.DaoRol().Insert(model);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Models.MRol model)
        {
            return new Daos.DaoRol().Update(model);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            return new Daos.DaoRol().Delete(Id, Usuario, Fecha);
        }
    }
}
