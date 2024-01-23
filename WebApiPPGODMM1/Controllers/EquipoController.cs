using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPPGODMM1.Controllers
{
    [RoutePrefix("api/Equipo")]
    public class EquipoController : ApiController
    {
        [Route("SelectById")]
        [HttpGet]
        public Models.MEquipo SelectById(int Id)
        {
            return new Daos.DaoEquipo().SelectById(Id);
        }
        [Route("SelectAll")]
        [HttpGet]
        public List<Models.MEquipo> SelectAll()
        {
            return new Daos.DaoEquipo().SelectAll();
        }
        [Route("Insert")]
        [HttpPost]
        public int Insert(Models.MEquipo model)
        {
            return new Daos.DaoEquipo().Insert(model);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Models.MEquipo model)
        {
            return new Daos.DaoEquipo().Update(model);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            return new Daos.DaoEquipo().Delete(Id, Usuario, Fecha);
        }

    }
}
