using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPPGODMM1.Controllers
{
    [RoutePrefix("api/RTecnico")]
    public class RTecnicoController : ApiController
    {

        [Route("SelectById")]
        [HttpGet]
        public Models.MRTecnico SelectById(int Id)
        {
            return new Daos.DaoRTecnico().SelectById(Id);
        }
        [Route("SelectAll")]
        [HttpGet]
        public List<Models.MRTecnico> SelectAll()
        {
            return new Daos.DaoRTecnico().SelectAll();
        }
        [Route("Insert")]
        [HttpPost]
        public int Insert(Models.MRTecnico model)
        {
            return new Daos.DaoRTecnico().Insert(model);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Models.MRTecnico model)
        {
            return new Daos.DaoRTecnico().Update(model);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            return new Daos.DaoRTecnico().Delete(Id, Usuario, Fecha);
        }
    }
}
