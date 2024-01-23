using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPPGODMM1.Controllers
{
    [RoutePrefix("api/Local")]
    public class LocalController : ApiController
    {
        [Route("SelectById")]
        [HttpGet]
        public Models.MLocal SelectById(int Id)
        {
            return new Daos.DaoLocal().SelectById(Id);
        }
        [Route("SelectAll")]
        [HttpGet]
        public List<Models.MLocal> SelectAll()
        {
            return new Daos.DaoLocal().SelectAll();
        }
        [Route("Insert")]
        [HttpPost]
        public int Insert(Models.MLocal model)
        {
            return new Daos.DaoLocal().Insert(model);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Models.MLocal model)
        {
            return new Daos.DaoLocal().Update(model);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            return new Daos.DaoLocal().Delete(Id, Usuario, Fecha);
        }
    }
}