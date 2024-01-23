using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiPPGODMM1.Controllers
{
    [RoutePrefix("api/Persona")]
    public class PersonaController : ApiController
    {

        [Route("SelectById")]
        [HttpGet]
        public Models.MPersona SelectById(int Id)
        {
            return new Daos.DaoPersona().SelectById(Id);
        }
        [Route("SelectAll")]
        [HttpGet]
        public List<Models.MPersona> SelectAll()
        {
            return new Daos.DaoPersona().SelectAll();
        }
        [Route("Insert")]
        [HttpPost]
        public int Insert(Models.MPersona model)
        {
            return new Daos.DaoPersona().Insert(model);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Models.MPersona model)
        {
            return new Daos.DaoPersona().Update(model);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(int Id, string Usuario, DateTime Fecha)
        {
            return new Daos.DaoPersona().Delete(Id, Usuario, Fecha);
        }
    }
}
