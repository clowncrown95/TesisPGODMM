using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPPGODMM1.Controllers
{
    [RoutePrefix("api/Estado")]
    public class EstadoController : ApiController
    {
        [Route("SelectById")]
        [HttpGet]
        public Models.MEstado SelectById(int Id)
        {
            return new Daos.DaoEstado().SelectById(Id);
        }
        [Route("SelectAll")]
        [HttpGet]
        public List<Models.MEstado> SelectAll()
        {
            return new Daos.DaoEstado().SelectAll();
        }
        [Route("Insert")]
        [HttpPost]
        public int Insert(Models.MEstado model)
        {
            return new Daos.DaoEstado().Insert(model);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Models.MEstado model)
        {
            return new Daos.DaoEstado().Update(model);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            return new Daos.DaoEstado().Delete(Id, Usuario, Fecha);
        }
    }
}
