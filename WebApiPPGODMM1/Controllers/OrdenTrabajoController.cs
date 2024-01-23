using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPPGODMM1.Controllers
{
    [RoutePrefix("api/OrdenTrabajo")]
    public class OrdenTrabajoController : ApiController
    {
        [Route("SelectById")]
        [HttpGet]
        public Models.MOrdenTrabajo SelectById(int Id)
        {
            return new Daos.DaoOrdenTrabajo().SelectById(Id);
        }
        [Route("SelectAll")]
        [HttpGet]
        public List<Models.MOrdenTrabajo> SelectAll()
        {
            return new Daos.DaoOrdenTrabajo().SelectAll();
        }
        [Route("Insert")]
        [HttpPost]
        public int Insert(Models.MOrdenTrabajo model)
        {
            return new Daos.DaoOrdenTrabajo().Insert(model);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Models.MOrdenTrabajo model)
        {
            return new Daos.DaoOrdenTrabajo().Update(model);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            return new Daos.DaoOrdenTrabajo().Delete(Id, Usuario, Fecha);
        }
    }
}
