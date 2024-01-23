using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPPGODMM1.Controllers
{
    [RoutePrefix("api/DetalleOrdenTrabajo")]
    public class DetalleOrdenTrabajoController : ApiController
    {
        [Route("SelectById")]
        [HttpGet]
        public Models.MDetalleOrdenTrabajo SelectById(int Id)
        {
            return new Daos.DaoDetalleOrdenTrabajo().SelectById(Id);
        }
        [Route("SelectAll")]
        [HttpGet]
        public List<Models.MDetalleOrdenTrabajo> SelectAll()
        {
            return new Daos.DaoDetalleOrdenTrabajo().SelectAll();
        }
        [Route("Insert")]
        [HttpPost]
        public int Insert(Models.MDetalleOrdenTrabajo model)
        {
            return new Daos.DaoDetalleOrdenTrabajo().Insert(model);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Models.MDetalleOrdenTrabajo model)
        {
            return new Daos.DaoDetalleOrdenTrabajo().Update(model);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            return new Daos.DaoDetalleOrdenTrabajo().Delete(Id, Usuario, Fecha);
        }
    }
}
